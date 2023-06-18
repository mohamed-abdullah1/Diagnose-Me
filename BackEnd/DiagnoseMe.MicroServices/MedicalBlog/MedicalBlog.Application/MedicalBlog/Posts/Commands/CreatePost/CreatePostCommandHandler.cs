using ErrorOr;
using MediatR;
using MedicalBlog.Application.Authentication.Helpers;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.Common.Interfaces.RabbitMQ;
using MedicalBlog.Application.Common.Interfaces.Services;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileHandler _fileHandler;
    private readonly IMessageQueueManager _messageQueueManager;

    public CreatePostCommandHandler(IPostRepository postRepository,
        IUserRepository userRepository,
        ITagRepository tagRepository,
        IUnitOfWork unitOfWork,
        IFileHandler fileHandler,
        IMessageQueueManager messageQueueManager)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
        _fileHandler = fileHandler;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var author = (await _userRepository.Get(
            predicate: x => x.Id == command.AuthorId,
            include: "Subscribers"))
            .FirstOrDefault();
        if (author == null)
            return Errors.User.NotFound;

        var tags = await _tagRepository.Get(x => command.Tags.Contains(x.TagName));
        var nonExistingTags = command.Tags.Except(tags.Select(x => x.TagName));
        var newTags = nonExistingTags.Select(x => new Tag{TagName = x});
        var allTags = tags.Concat(newTags).ToList();

        var result = new ErrorOr<string>();
        var postImages = new List<PostImage>();
        var postId = Guid.NewGuid().ToString();

        if (command.Base64Images.Count() > 5)
            return Errors.Post.TooManyImages;
        
        foreach(var base64Image in command.Base64Images){
            result = SaveFile.SavePicture(base64Image,_fileHandler);

            if(result.IsError)
                return result.Errors;
            
            postImages.Add(new PostImage{
                PostId = postId,
                ImageUrl = result.Value
            });
        };

        Post post = new Post{
            Id = postId,
            Title = command.Title,
            Content = command.Content,
            AuthorId = command.AuthorId,
            CreatedOn = DateTime.UtcNow
        };
        post.Tags = allTags;
        post.Author = author;
        post.PostImages = postImages;

        
            
        
        await _postRepository.AddAsync(post);
        if (await _unitOfWork.Save() == 0)
            return Errors.Post.CreationFailed;
        
        foreach(var user in author.Subscribers){
            _messageQueueManager.PublishNotification(new NotificationResponse(
                SenderId: author.Id!,
                RecipientId: user.Id!,
                Message: $"New post from Dr. {author.Name}"));
        }
        
        return new CommandResponse(
            true,
            "Post created successfully",
            $"posts/{post.Id}");
    }
}