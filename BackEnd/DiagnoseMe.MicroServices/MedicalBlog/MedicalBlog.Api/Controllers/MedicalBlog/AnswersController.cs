using MapsterMapper;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Answers.Commands.AddAnswer;
using MedicalBlog.Application.MedicalBlog.Answers.Commands.Agreement;
using MedicalBlog.Application.MedicalBlog.Answers.Commands.DeleteAnswer;
using MedicalBlog.Application.MedicalBlog.Answers.Commands.EditAnswer;
using MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByQuestionId;
using MedicalBlog.Contracts.MedicalBlog.Answers;
using MedicalBlog.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBlog.Api.Controllers.MedicalBlog;


[Route("api/v1")]
[ApiController]
public class AnswersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AnswersController(
        ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }  

    [Authorize]
    [HttpGet("questions/question-id/{questionId}/answers/page-number/{pageNumber}")]
    public async Task<IActionResult> GetAnswersByQuestionId(string questionId, int pageNumber)
    {
        var query = new GetAnswersByQuestionIdQuery(questionId, pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    } 

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("questions/question-id/{questionId}/answer")]
    public async Task<IActionResult> AddAnswerQuestion(AddAnswerRequest request, string questionId)
    {
        var command = new AnswerCommand(
            GetUserIdFromToken(),
            questionId,
            request.AnswerString);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("questions/answers/answer-id/{answerId}/edit")]
    public async Task<IActionResult> EditAnswerQuestion(EditAnswerRequest request, string answerId)
    {
        var command = new EditAnswerCommand(
            GetUserIdFromToken(),
            answerId,
            request.AnswerString);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor + "," + Roles.Admin)]
    [HttpDelete("questions/answers/answer-id/{answerId}/delete")]
    public async Task<IActionResult> DeleteAnswerQuestion(string answerId)
    {
        var command = new DeleteAnswerCommand(
            GetUserIdFromToken(),
            answerId,
            GetUserRolesFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor + "," + Roles.Admin)]
    [HttpPost("questions/answers/answer-id/{answerId}/agreement/{isAgree:bool}")]
    public async Task<IActionResult> Agreement(string answerId, bool isAgree)
    {
        var command = new AnswerAgreementCommand(
            answerId,
            GetUserIdFromToken(),
            isAgree);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}