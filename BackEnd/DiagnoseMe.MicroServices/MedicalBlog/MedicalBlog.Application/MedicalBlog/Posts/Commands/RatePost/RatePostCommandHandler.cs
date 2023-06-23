using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.RatePost;


public class RatePostCommandHandler : IRequestHandler<RatePostCommand, ErrorOr<CommandResponse>>
{
private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRatingRepository _postRatingRepository;
    public RatePostCommandHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IPostRatingRepository postRatingRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _postRatingRepository = postRatingRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(RatePostCommand command, CancellationToken cancellationToken)
    {
        var post = (await _postRepository.Get(
            predicate: x => x.Id == command.PostId,
            include: "RatingUsers"))
            .FirstOrDefault();

        if (post == null)
            return Errors.Post.NotFound;

        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

        if (post.AuthorId == user.Id)
            return Errors.User.YouCanNotDoThis;

        var postRatings = (await _postRatingRepository.Get(
            predicate: x => x.PostId == post.Id )).ToList();

        var userRating = postRatings.FirstOrDefault(x => x.UserId == user.Id);
        
        if (userRating != null)
        {
            userRating.Rating = command.Rating;
            post.AverageRate = (postRatings.Sum(x => x.Rating) - userRating.Rating + command.Rating) / (postRatings.Count);;
            await _postRatingRepository.Edit(userRating);
        }
        else
        {
            await _postRatingRepository.AddAsync( new PostRating
            {
                UserId = user.Id!,
                PostId = post.Id!,
                Rating = command.Rating,
                User = user,
                Post = post
            });
            post.AverageRate = (postRatings.Sum(x => x.Rating) + command.Rating) / (postRatings.Count + 1);
        }



        if (await _postRatingRepository.SaveAsync() == 0)
            return Errors.Post.FailedToAddRating;
            
        return new CommandResponse(
            true,
            $"You have successfully rated this post with id {command.PostId}.",
            null!);
    }
}