using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Comments.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Queries.GetCommentsyParentId;

public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByParentIdQuery, ErrorOr<PageResponse>>
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
    public async Task<ErrorOr<PageResponse>> Handle(GetCommentsByParentIdQuery query, CancellationToken cancellationToken)
    {
        var comments = (await _commentRepository.Get(
            predicate: c => c.ParentId == query.ParentId,
            include: "Auther,AgreeingUsers,ChildComments"));

        var IsNextPage = comments.Count() > query.PageNumber * 10;

        var resultComments = comments
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();

        var commentsResponse = _mapper.Map<List<CommentResponse>>(resultComments);

        return new PageResponse(
            commentsResponse.Select(c => (object)c).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}