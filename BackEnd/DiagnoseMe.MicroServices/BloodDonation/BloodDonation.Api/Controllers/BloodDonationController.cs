using BloodDonation.Application.BloodDonation.Commands.AcceptDonation;
using BloodDonation.Application.BloodDonation.Commands.CancelDonation;
using BloodDonation.Application.BloodDonation.Commands.CommpleteDonation;
using BloodDonation.Application.BloodDonation.Commands.RequestDonation;
using BloodDonation.Application.BloodDonation.Commands.ReviewRequest;
using BloodDonation.Application.BloodDonation.Queries.GetByBloodType;
using BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;
using BloodDonation.Application.BloodDonation.Queries.GetByStatus;
using BloodDonation.Contracts.BloodDonation;
using BloodDonation.Domain.Common.Roles;
using BloodDonation.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Api.Controllers;


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

    [Authorize]
    [HttpPost("request")]
    public async Task<IActionResult> CreateRequest(DonationRequestRequest request)
    {
        var command = _mapper.Map<RequestDonationCommand>((request, GetUserIdFromToken()));
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("request/{requestId}/cancel")]
    public async Task<IActionResult> CancelRequest(string requestId)
    {
        var command = new CancelDonationCommand(
            requestId,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("request/{requestId}/accept")]
    public async Task<IActionResult> AcceptRequest(string requestId)
    {                     
        var command = new AcceptDonationCommand(
            requestId,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("request/{requestId}/complete")]
    public async Task<IActionResult> RejectRequest(string requestId)
    {
        var command = new CommpleteDonationCommand(
            requestId,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("request/{requestId}/review/{isAccepted}")]
    public async Task<IActionResult> ReviewRequest(string requestId, bool isAccepted, string? reason = null)
    {
        var command = new ReviewRequestCommand(
            requestId,
            isAccepted,
            reason,
            GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}