using BloodDonation.Application.BloodDonation.Queries.GetByBloodType;
using BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;
using BloodDonation.Application.BloodDonation.Queries.GetByStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Api.Controllers;

[Route("api")]
public class BloodDonationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public BloodDonationController(ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpGet("health-check")]
    public ActionResult HealthCheck()
    {
        
        return Ok(true);
    }
    
    [Authorize]
    [HttpGet("requests/blood-type/{bloodType}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetByBloodType(string bloodType, int pageNumber)
    {
        var query = new GetByBloodTypeQuery(
            bloodType,
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("requests/mine/page-number/{pageNumber}")]
    public async Task<IActionResult> GetMine(int pageNumber)
    {
        var query = new GetByRequesterIdQuery(
            GetUserIdFromToken(),
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize]
    [HttpGet("requests/requester-id/{requesterId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetByRequesterId(string requesterId, int pageNumber)
    {
        var query = new GetByRequesterIdQuery(
            requesterId,
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("requests/status/{status}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetByStatus(string status, int pageNumber)
    {
        var query = new GetByStatusQuery(
            status,
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}