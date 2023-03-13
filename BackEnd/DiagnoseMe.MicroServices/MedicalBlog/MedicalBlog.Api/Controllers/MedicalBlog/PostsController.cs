using MapsterMapper;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.CreatePost;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.DeletePost;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.EditPost;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.RatePost;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.SubscribeDoctor;
using MedicalBlog.Application.MedicalBlog.Posts.Commands.UnsubscribeDoctor;
using MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostById;
using MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPosts;
using MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostsByDocterId;
using MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostsByTags;
using MedicalBlog.Contracts.MedicalBlog.Posts;
using MedicalBlog.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBlog.Api.Controllers.MedicalBlog;

[Route("api/v1")]
[ApiController]

public class PostsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public PostsController(
        ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    } 

    [Authorize]
    [HttpGet("posts/page-number/{pageNumber}")]
    public async Task<IActionResult> GetPosts(int pageNumber)
    {
        var query = new GetPostsQuery(
            pageNumber,
            GetUserIdFromToken());
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("posts/post-id/{postId}")]
    public async Task<IActionResult> GetPostById(string postId)
    {
        var query = new GetPostByIdQuery(
            postId,
            GetUserIdFromToken());
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpGet("posts/doctor-id/{DoctorId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetPostsByDoctorId(string DoctorId, int pageNumber)
    {
        var query = new GetPostsByDoctorIdQuery(
            DoctorId, 
            pageNumber,
            GetUserIdFromToken());
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpPost("posts/tags")]
    public async Task<IActionResult> GetPostsByTags(GetPostsByTagsRequest request)
    {
        var query = new GetPostsByTagsQuery(
            request.PageNumber,
            request.Tags,
            GetUserIdFromToken());
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/create")]
    public async Task<IActionResult> CreatePost(CreatePostRequest request)
    {
        var command = new CreatePostCommand(
            GetUserIdFromToken(),
            request.Title,
            request.Content,
            request.Tags);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/post-id/{postId}/edit")]
    public async Task<IActionResult> EditPost(EditPostRequest request, string postId)
    {
        var command = new EditPostCommand(
            postId,
            request.Title,
            request.Content,
            request.Tags,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor + "," + Roles.Admin)]
    [HttpDelete("posts/post-id/{postId}/delete")]
    public async Task<IActionResult> DeletePost(string postId)
    {
        var command = new DeletePostCommand(
            postId,
            GetUserIdFromToken(),
            GetUserRolesFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("posts/post-id/{postId}/rating")]
    public async Task<IActionResult> RatePost(RatePostRequest request, string postId)
    {
        var command = new RatePostCommand(
            postId,
            request.Rating,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpPost("subscribe/Doctor-id/{doctorId}")]
    public async Task<IActionResult> Subscribe(string doctorId)
    {
        var command = new SubscribeDoctorCommand(
            doctorId,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpPost("unsubscribe/Doctor-id/{doctorId}")]
    public async Task<IActionResult> Unsubscribe(string doctorId)
    {
        var command = new UnsubscribeDoctorCommand(
            doctorId,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
}