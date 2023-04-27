using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, ErrorOr<CommandResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    public AddCommentCommandHandler(
        ICommentRepository commentRepository,
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddCommentCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.PostId);
        if (post == null)
        {
            return Errors.Post.NotFound;
        }
        var author = await _userRepository.GetByIdAsync(command.AuthorId);
        if (author == null)
        {
            // Todo: check user in auth service
            return Errors.User.NotFound;
        }
        var comment = new Comment{
            Id = Guid.NewGuid().ToString(),
            Content = command.Content,
            AuthorId = command.AuthorId,
            PostId = command.PostId,
            ParentId = Guid.Empty.ToString(),
        };
        comment.Author = author;
        comment.Post = post;
        
        await _commentRepository.AddAsync(comment);

        if (await _commentRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Comment.AddFailed;
                
        return new CommandResponse(
            true,
            "Comment added successfully",
            $"posts/{command.PostId}"
        );
    }
}