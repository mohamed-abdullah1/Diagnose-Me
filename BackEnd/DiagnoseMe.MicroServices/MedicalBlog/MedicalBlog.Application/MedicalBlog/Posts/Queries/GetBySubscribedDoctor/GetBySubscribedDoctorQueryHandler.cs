using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Posts.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetBySubscribedDoctor;

public class GetBySubscribedDoctorQueryHandler : IRequestHandler<GetBySubscribedDoctorQuery, ErrorOr<PageResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetBySubscribedDoctorQueryHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetBySubscribedDoctorQuery query, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.Get(
            predicate: x => x.Id == query.UserId,
            include: "SubscribedDoctors"))
            .FirstOrDefault();

        if (user == null)
            return Errors.User.NotFound;

        var posts = (await _postRepository.Get(
            predicate: p => user.SubscribedUsers.Any(x => x.Id == p.AuthorId),
            include: "Author,Tags,Comments,ViewingUsers,RatingUsers,PostImages"));
        
        var IsNextPage = posts.Count() > query.PageNumber * 10;

        var resultPosts = posts.
            OrderByDescending(x => x.CreatedOn).
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        
        foreach (var post in posts)
        {
            if(!post.ViewingUsers.Any(x => x.Id == user.Id)){
                post.ViewingUsers.Add(user);
            }
            await _postRepository.SaveAsync();
        }

        var postsResponses = _mapper.Map<List<PostResponse>>(resultPosts);
        
        return new PageResponse(
            postsResponses.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}