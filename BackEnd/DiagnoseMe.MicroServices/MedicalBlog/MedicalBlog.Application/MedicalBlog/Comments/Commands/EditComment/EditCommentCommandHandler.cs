using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.EditComment;

public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, ErrorOr<CommandResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    
    public EditCommentCommandHandler(
        ICommentRepository commentRepository, 
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<CommandResponse>> Handle(EditCommentCommand command, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(command.CommentId);
        if (comment is null)
            return Errors.Comment.NotFound;
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null){
            // TODO: Check user in auth service
            return Errors.User.NotFound;
        }
        if (comment.Author.Id != user.Id)
            return Errors.User.YouCanNotDoThis;
        comment.Content = command.Content;
        comment.ModifiedOn = DateTime.UtcNow;
        

        await _commentRepository.Edit(comment);
        if (await _commentRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Comment.EditFailed;
        

        return new CommandResponse(
            true,
            $"Comment with id: {comment.Id} was edited.",
            $"posts/{comment.PostId}"
        );
    }
}