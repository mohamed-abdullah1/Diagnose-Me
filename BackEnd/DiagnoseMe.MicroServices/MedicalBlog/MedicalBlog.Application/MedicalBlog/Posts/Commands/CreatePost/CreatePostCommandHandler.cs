
using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.RabbitMQ;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common;
using MedicalBlog.Domain.Common.Errors;
using Microsoft.AspNetCore.Http;
using MedicalBlog.Application.MedicalBlog.Helpers;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public CreatePostCommandHandler(IPostRepository postRepository,
        IUserRepository userRepository,
        ITagRepository tagRepository,
        IMessageQueueManager messageQueueManager)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _tagRepository = tagRepository;
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

        var result = new ErrorOr<IFormFile>();
        var rMQFilesResponse = new List<RMQFileResponse>();
        var postImages = new List<PostImage>();
        var postId = Guid.NewGuid().ToString();

        if (command.Base64Images.Count() > 5)
            return Errors.Post.TooManyImages;
        
        foreach(var base64Image in command.Base64Images){
            result = FileConverter.ConvertToPng(base64Image);

            if(result.IsError)
                return result.Errors;
            
            postImages.Add(new PostImage{
                PostId = postId,
                ImageUrl = Path.Combine(StaticPaths.BlogImagesPath, result.Value.Name)
            });

            rMQFilesResponse.Add(new RMQFileResponse(
                FilePath: StaticPaths.BlogImagesPath,
                File: result.Value));
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
        if (await _postRepository.SaveAsync() == 0)
            return Errors.Post.CreationFailed;
        
        foreach(var user in author.Subscribers){
            _messageQueueManager.PublishNotification(new NotificationResponse(
                SenderId: author.Id!,
                RecipientId: user.Id!,
                Message: $"New post from Dr. {author.Name}"));
        }

        
        _messageQueueManager.PublishFile(rMQFilesResponse);
        
        
        return new CommandResponse(
            true,
            "Post created successfully",
            $"posts/{post.Id}");
    }
}