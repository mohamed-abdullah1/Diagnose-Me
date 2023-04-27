using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCommandHandler(IPostRepository postRepository,
        IUserRepository userRepository,
        ITagRepository tagRepository,
        IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var author = await _userRepository.GetByIdAsync(command.AuthorId);
        if (author == null)
            return Errors.User.NotFound;

        var tags = await _tagRepository.Get(x => command.Tags.Contains(x.TagName));
        var nonExistingTags = command.Tags.Except(tags.Select(x => x.TagName));
        var newTags = nonExistingTags.Select(x => new Tag{TagName = x});
        var allTags = tags.Concat(newTags).ToList();
        
        Post post = new Post{
            Id = Guid.NewGuid().ToString(),
            Title = command.Title,
            Content = command.Content,
            AuthorId = command.AuthorId,
            CreatedOn = DateTime.UtcNow
        };
        post.Tags = allTags;
        post.Author = author;

        await _postRepository.AddAsync(post);
        if (await _unitOfWork.Save() == 0)
            return Errors.Post.CreationFailed;

        return new CommandResponse(
            true,
            "Post created successfully",
            $"posts/{post.Id}");
    }
}