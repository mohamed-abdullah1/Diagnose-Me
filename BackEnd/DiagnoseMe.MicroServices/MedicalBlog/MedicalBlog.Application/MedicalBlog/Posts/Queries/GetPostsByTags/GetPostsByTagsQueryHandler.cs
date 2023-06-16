using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MapsterMapper;
using MedicalBlog.Application.MedicalBlog.Posts.Common;
using MedicalBlog.Domain.Common.Errors;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostsByTags;


public class GetPostsByTagsQueryHandler : IRequestHandler<GetPostsByTagsQuery, ErrorOr<PageResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPostsByTagsQueryHandler(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetPostsByTagsQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId);
        if (user == null)
            return Errors.User.NotFound;

        var posts = (await _postRepository.Get(
            predicate: x => x.Tags.Any(t => query.Tags.Contains(t.TagName)),
            include: "RatingUsers,Author,Tags,Comments,ViewingUsers,PostImages"));
        
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

        var postsResponses = _mapper.Map<List<PostResponse>>(posts);
        
        return new PageResponse(
            postsResponses.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}