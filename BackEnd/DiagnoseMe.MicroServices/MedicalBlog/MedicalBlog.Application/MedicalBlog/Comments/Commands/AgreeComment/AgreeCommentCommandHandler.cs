using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.AgreeComment;


public class AgreeCommentCommandHandler : IRequestHandler<AgreeCommentCommand, ErrorOr<CommandResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly ICommentAgreementRepository _commentAgreementRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AgreeCommentCommandHandler(
        ICommentRepository commentRepository,
        ICommentAgreementRepository commentAgreementRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _commentAgreementRepository = commentAgreementRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AgreeCommentCommand command, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(command.CommentId);
        if (comment == null)
            return Errors.Comment.NotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

        var commentAgreement = (await _commentAgreementRepository.Get(
            predicate: ca => ca.CommentId == command.CommentId && ca.UserId == command.UserId)).
            FirstOrDefault();
        
        if (commentAgreement != null)
        {
            if (commentAgreement.IsAgreed == command.IsAgreed)
                return Errors.Comment.AlreadyAgreed;
            
            commentAgreement.IsAgreed = command.IsAgreed;
            comment.AgreementCount += command.IsAgreed ? 1 : -1;
        }
        else
        {
            commentAgreement = new CommentAgreement
            {
                Id = Guid.NewGuid().ToString(),
                CommentId = command.CommentId,
                UserId = command.UserId,
                IsAgreed = command.IsAgreed,
                Comment = comment,
                User = user
            };
            comment.AgreementCount += command.IsAgreed ? 1 : 0;
            await _commentAgreementRepository.AddAsync(commentAgreement);
        }   

        if(await _unitOfWork.Save() == 0)
            return Errors.Comment.AgreementFailed;
        return new CommandResponse(
            true,
            "Comment agreement changed successfully",
            $"comments/{command.CommentId}"
        );
    }
}