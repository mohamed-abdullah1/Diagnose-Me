using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck;
using MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;
using MedicalServices.Application.MedicalServices.Checks.Commands.UpdateCheck;
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
}
