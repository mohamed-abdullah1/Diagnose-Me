using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.UnSavePost;


public class UnSavePostCommandHandler : IRequestHandler<UnSavePostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UnSavePostCommandHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UnSavePostCommand command, CancellationToken cancellationToken)
    {
        var post = (await _postRepository.Get(
            predicate: x => x.Id == command.PostId,
            include: "SavingUsers"))
            .FirstOrDefault();

        if (post is null)
            return Errors.Post.NotFound;
        

        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;
        
        if (!post.SavingUsers.Any(x => x.Id == user.Id))
           return Errors.Post.NotSaved;
        
        post.SavingUsers.Remove(user);

        if (await _unitOfWork.Save() == 0)
            return Errors.Post.UnSaveFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Post unsaved successfully",
            Path: $"posts/{post.Id}"
        );

    }
}