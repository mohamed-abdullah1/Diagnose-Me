using MapsterMapper;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Questions.Commands.Agreement;
using MedicalBlog.Application.MedicalBlog.Questions.Commands.Ask;
using MedicalBlog.Application.MedicalBlog.Questions.Commands.DeleteQuestion;
using MedicalBlog.Application.MedicalBlog.Questions.Commands.EditQuestion;
using MedicalBlog.Application.MedicalBlog.Questions.Queries.GetImportantQuestions;
using MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionById;
using MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestions;
using MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionsByAskingUserId;
using MedicalBlog.Contracts.MedicalBlog.Questions;
using MedicalBlog.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBlog.Api.Controllers.MedicalBlog;


public class QuestionsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public QuestionsController(
        ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("questions/page-number/{pageNumber}")]
    public async Task<IActionResult> GetQuestions(int pageNumber, string? q, string? tag)
    {
        var query = new GetQuestionsQuery(
            pageNumber,
            q!,
            tag!);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpGet("questions/question-id/{questionId}")]
    public async Task<IActionResult> GetQuestionById(string questionId)
    {
        var query = new GetQuestionByIdQuery(questionId);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("questions/asking-user-id/{askingUserId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetQuestionsByAskingUserId(string askingUserId, int pageNumber)
    {
        var query = new GetQuestionsByAskingUserIdQuery(pageNumber, askingUserId);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("questions/ask")]
    public async Task<IActionResult> AskQuestion(AskRequest request)
    {
        var command = new AskCommand(
            GetUserIdFromToken(),
            request.QuestionString,
            request.Tags);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpPost("questions/question-id/{questionId}/edit")]
    public async Task<IActionResult> EditQuestion(EditQuestionRequest request, string questionId)
    {
        var command = new EditQuestionCommand(
            questionId,
            request.QuestionString,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpDelete("questions/question-id/{questionId}/delete")]
    public async Task<IActionResult> DeleteQuestion(string questionId)
    {
        var command = new DeleteQuestionCommand(
            questionId,
            GetUserIdFromToken(),
            GetUserRolesFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor + "," + Roles.Admin)]
    [HttpPost("questions/question-id/{questionId}/agreement/{isAgreement:bool}")]
    public async Task<IActionResult> Agreement(string questionId, bool isAgreement)
    {
        var command = new QuestionAgreementCommand(
            questionId,
            GetUserIdFromToken(),
            isAgreement);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize]
    [HttpGet("questions/important")]
    public async Task<IActionResult> GetImportantQuestions()
    {
        var query = new GetImportantQuestionsQuery();
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}