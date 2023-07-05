using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Posts.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPopularPosts;

public class GetPopularPostsQueryHandler : IRequestHandler<GetPopularPostsQuery, ErrorOr<PageResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPopularPostsQueryHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetPopularPostsQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId);
        var posts = await _postRepository.Get(
            include: "Author,Tags,Comments,ViewingUsers,RatingUsers,PostImages"
        );
        var popularPosts = posts.
            OrderByDescending(p => p.ViewsCount + p.Comments.Count+ p.AverageRate) 
            .Take(10);
        if(user != null)
        {
            foreach (var post in popularPosts)
            {
                if(!post.ViewingUsers.Any(x => x.Id == user.Id)){
                    post.ViewingUsers.Add(user);
                }
                await _postRepository.SaveAsync();
            }
        }
        var popularPostsResponse = _mapper.Map<List<PostResponse>>(popularPosts);
        return new PageResponse(
            Objects: popularPostsResponse.Select(p => (object)p).ToList(),
            CurrentPage: 1,
            IsNextPage: false
        );
    
    }
}