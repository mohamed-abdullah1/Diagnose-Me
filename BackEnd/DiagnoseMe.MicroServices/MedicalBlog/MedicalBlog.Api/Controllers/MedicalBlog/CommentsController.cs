using MapsterMapper;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Comments.Commands.AddComment;
using MedicalBlog.Application.MedicalBlog.Comments.Commands.AgreeComment;
using MedicalBlog.Application.MedicalBlog.Comments.Commands.DeleteComment;
using MedicalBlog.Application.MedicalBlog.Comments.Commands.EditComment;
using MedicalBlog.Application.MedicalBlog.Comments.Commands.ReplyComment;
using MedicalBlog.Application.MedicalBlog.Comments.Queries.GetCommentsByPostId;
using MedicalBlog.Application.MedicalBlog.Comments.Queries.GetCommentsyParentId;
using MedicalBlog.Contracts.MedicalBlog.Comments;
using MedicalBlog.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBlog.Api.Controllers.MedicalBlog;




public class CommentsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public CommentsController(
        ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    } 

    [Authorize]
    [HttpGet("posts/post-id/{postId}/comments/page-number/{pageNumber}")]
    public async Task<IActionResult> GetCommentsByPostId(string postId, int pageNumber)
    {
        var query = new GetCommentsByPostIdQuery(postId, pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    
    [Authorize]
    [HttpGet("posts/post-id/{postId}/comments/parent-id/{parentId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetCommentsByParentId(string postId, string parentId, int pageNumber)
    {
        var query = new GetCommentsByParentIdQuery(parentId, pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/post-id/{postId}/comments/add")]
    public async Task<IActionResult> AddComment(AddCommentRequest request, string postId)
    {
        var command = new AddCommentCommand(
            request.Content,
            GetUserIdFromToken(),
            postId);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/comments/comment-id/{commentId}/edit")]
    public async Task<IActionResult> EditComment(EditCommentRequest request, string commentId)
    {
        var command = new EditCommentCommand(
            commentId,
            request.Content,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor + "," + Roles.Admin)]
    [HttpDelete("posts/comments/comment-id/{commentId}/delete")]
    public async Task<IActionResult> DeleteComment(string commentId)
    {
        var command = new DeleteCommentCommand(
            commentId,
            GetUserIdFromToken(),
            GetUserRolesFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/post-id/{postId}/comments/comment-id/{commentId}/reply")]
    public async Task<IActionResult> ReplyToComment(ReplyToCommentRequest request, string commentId, string postId)
    {
        var command = new ReplyToCommentCommand(
            postId,
            commentId,
            GetUserIdFromToken(),
            request.Content);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/comments/comment-id/{commentId}/agreement/{isAgreed:bool}")]
    public async Task<IActionResult> AgreeComment(string commentId, bool isAgreed)
    {
        var command = new AgreeCommentCommand(
            commentId,
            GetUserIdFromToken(),
            isAgreed);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

}