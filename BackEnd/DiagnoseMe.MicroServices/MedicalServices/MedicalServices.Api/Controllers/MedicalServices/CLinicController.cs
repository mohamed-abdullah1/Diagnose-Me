using System.Net;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Clinics.Common;
using MedicalServices.Application.Clinics.Queries.GetClinicAddresses;
using MedicalServices.Application.Clinics.Queries.GetClinicDoctors;
using MedicalServices.Application.Clinics.Queries.GetClinics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers.MedicalServices;


[Route("api")]
public class ClinicController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public ClinicController(ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }
    [Authorize]
    [HttpGet("clinics/page-number/{page-number}")]
    public async Task<IActionResult> GetClinics(int pageNumber)
    {

        var query = new GetClinicsQuery(pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize]
    [HttpGet("clinics/{clinic-id}/addresses/page-number/{page-number}")]
    public async Task<IActionResult> GetClinicsAddresses(int pageNumber,string clinicId)
    {

        var query = new GetClinicAddressesQuery(clinicId,pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("clinics/{clinic-id}/doctors/page-number/{page-number}")]
    public async Task<IActionResult> GetClinicsDoctors(int pageNumber,string clinicId)
    {

        var query = new GetClinicDoctorsQuery(clinicId,pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}