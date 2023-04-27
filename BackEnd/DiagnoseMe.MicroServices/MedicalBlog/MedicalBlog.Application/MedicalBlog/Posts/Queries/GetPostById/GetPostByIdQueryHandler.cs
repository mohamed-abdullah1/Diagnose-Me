using ErrorOr;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MediatR;
using MedicalBlog.Domain.Common.Errors;
using MapsterMapper;
using MedicalBlog.Application.MedicalBlog.Posts.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostById;

public class GetPostQueryHandler : IRequestHandler<GetPostByIdQuery, ErrorOr<PostResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPostQueryHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<PostResponse>> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {    
        var user = await _userRepository.GetByIdAsync(query.UserId);
        if (user == null)
            return Errors.User.NotFound;

        var post = (await _postRepository.Get(
            predicate: x => x.Id == query.Id,
            include: "RatingUsers,Author,Tags,Comments,ViewingUsers")).FirstOrDefault();

        if (post == null)
            return Errors.Post.NotFound;

        if(!post.ViewingUsers.Any(x => x.Id == user.Id)){
            post.ViewingUsers.Add(user);
            await _postRepository.SaveAsync();
        }

        var postResponse = _mapper.Map<PostResponse>(post);
        return postResponse;
    }  
}

