using BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByBloodType;
using BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByRequesterId;
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

    [Authorize]
    [HttpGet("blood-donation-requests/blood-type/{bloodType}")]
    public async Task<IActionResult> GetBloodDonationRequestsByBloodType(string bloodType)
    {
        var query = new GetBloodDonationRequestsByBloodTypeQuery(bloodType);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("blood-donation-requests/requester-id/{requesterId}")]
    public async Task<IActionResult> GetBloodDonationRequestsByRequesterId(string requesterId)
    {
        var query = new GetBloodDonationRequestsByRequesterIdQuery(requesterId);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}