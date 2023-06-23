using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.SavePost;

public class SavePostCommandHandler : IRequestHandler<SavePostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public SavePostCommandHandler(
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(SavePostCommand command, CancellationToken cancellationToken)
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
        var ifSaved = post.SavingUsers.Any(x => x.Id == user.Id);
        if (ifSaved)
        {
            post.SavingUsers.Remove(user);
        }
        else
        {
        post.SavingUsers.Add(user);}

        if (await _postRepository.SaveAsync() == 0)
            return Errors.Post.SaveFailed;
        var message = ifSaved ? "saved" : "unsaved";
        return new CommandResponse(
            Success: true,
            Message: $"Post {message} successfully",
            Path: $"posts/{post.Id}"
        );

    }
}