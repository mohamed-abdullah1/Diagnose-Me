using ErrorOr;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MediatR;
using MapsterMapper;
using MedicalBlog.Application.MedicalBlog.Comments.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Queries.GetCommentsByPostId;

public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostIdQuery, ErrorOr<List<CommentResponse>>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public GetCommentsByPostIdQueryHandler(
        ICommentRepository commentRepository,
        IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<List<CommentResponse>>> Handle(GetCommentsByPostIdQuery query, CancellationToken cancellationToken)
    {
        var comments = (await _commentRepository.Get(
            predicate: c => c.PostId == query.PostId && c.ParentId == Guid.Empty.ToString(),
            include: "Auther,AgreeingUsers,ChildComments"))
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .ToList();
        
        var commentsResponse = _mapper.Map<List<CommentResponse>>(comments);
        return commentsResponse;
    }
}
