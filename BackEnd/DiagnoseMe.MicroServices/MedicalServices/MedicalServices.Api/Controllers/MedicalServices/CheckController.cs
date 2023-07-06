using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck;
using MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;
using MedicalServices.Application.MedicalServices.Checks.Commands.UpdateCheck;
using MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByDoctorId;
using MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByPatientId;
using MedicalServices.Contracts.Checks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers.MedicalServices;



public class CheckController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public CheckController(ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }
    [Authorize]
    [HttpPost("check/add")]
    public async Task<IActionResult> AddCheck(AddCheckRequest request)
    {
        var command = _mapper.Map<AddCheckCommand>((request, 
            GetUserIdFromToken(),
            GetUserRolesFromToken()));
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
    [Authorize]
    [HttpDelete("check/delete/check-id/{checkId}")]
    public async Task<IActionResult> DeleteCheck(string checkId)
    {
        var command = new DeleteCheckCommand(
            GetUserIdFromToken(),
            GetUserRolesFromToken(),
            checkId);
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("check/update")]
    public async Task<IActionResult> UpdateCheck(UpdateCheckRequest request)
    {
        var command = _mapper.Map<UpdateCheckCommand>((request, 
            GetUserIdFromToken(),
            GetUserRolesFromToken()));
        var result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("check/get-checks/doc-id/{doctorId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetChecksByDoctorId(string doctorId, int pageNumber)
    {
        var query = new GetChecksByDoctorIdQuery(
            doctorId, 
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("check/get-checks/patient-id/{patientId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetChecksByPatientId(string patientId, int pageNumber)
    {
        var query = new GetChecksByPatientIdQuery(
            patientId, 
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}
