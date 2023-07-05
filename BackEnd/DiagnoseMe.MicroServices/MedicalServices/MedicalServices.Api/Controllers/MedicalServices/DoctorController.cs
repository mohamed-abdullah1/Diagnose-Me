using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctor;
using MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctorRate;
using MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctor;
using MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctorRate;
using MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctor;
using MedicalServices.Application.MedicalServices.Doctors.Commands.UpdatePricePerSession;
using MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctor;
using MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorRatesByDoctorId;
using MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctors;
using MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorsByPatientId;
using MedicalServices.Application.MedicalServices.Doctors.Queries.GetPopularDoctors;
using MedicalServices.Contracts.Doctors;
using MedicalServices.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers.MedicalServices;

public class DoctorController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public DoctorController(ISender mediator, 
        IMapper mapper,
        Serilog.ILogger logger) : base(logger)
    {

        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("doctors/page-number/{pageNumber}")]
    public async Task<IActionResult> GetDoctors(int pageNumber, string? name)
    {

        var query = new GetDoctorsQuery(
            name,
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/{doctorId}")]
    public async Task<IActionResult> GetDoctor(string doctorId)
    {

        var query = new GetDoctorQuery(doctorId);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/patient-id/{patientId}/page-number/{pageNumber}")]
    public async Task<IActionResult> GetDoctorsByPatientId(string patientId, int pageNumber)
    {

        var query = new GetDoctorsByPatientIdQuery(patientId, pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize(Roles =Roles.Admin)]
    [HttpPost("doctors/add/{doctorId}")]
    public async Task<IActionResult> AddDoctor(AddDoctorRequest request, string doctorId)
    {
        
        var command = _mapper.Map<AddDoctorCommand>((request, doctorId));
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor+","+Roles.Admin)]
    [HttpPost("doctors/update/{doctorId?}")]
    public async Task<IActionResult> UpdateDoctor(UpdateDoctorRequest request, string doctorId = null!)
    {
        if (User.IsInRole(Roles.Admin))
        {
            if (string.IsNullOrEmpty(doctorId))
            {
                var errors = new List<Error>
                {
                    Error.Validation(
                        code: "DoctorController.UpdateDoctor.DoctorId",
                        description: "User Id is required for admin")
                };
                return Problem(errors);
            }
        }
        else
        {
            doctorId = GetUserIdFromToken();
        }
        var command = _mapper.Map<UpdateDoctorCommand>((request, doctorId));
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor+","+Roles.Admin)]
    [HttpDelete("doctors/delete/{doctorId?}")]
    public async Task<IActionResult> DeleteDoctor(string doctorId = null!)
    {
        if (User.IsInRole(Roles.Admin))
        {
            if (string.IsNullOrEmpty(doctorId))
            {
                var errors = new List<Error>
                {
                    Error.Validation(
                        code: "DoctorController.DeleteDoctor.DoctorId",
                        description: "User Id is required for admin")
                };
                return Problem(errors);
            }
        }
        else
        {
            doctorId = GetUserIdFromToken();
        }
        var command = new DeleteDoctorCommand(doctorId);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpPost("doctors/rate")]
    public async Task<IActionResult> AddDoctorRating(AddDoctorRateRequest request)
    {
        var command = _mapper.Map<AddDoctorRateCommand>((request, GetUserIdFromToken()));
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }


    [Authorize]
    [HttpDelete("doctors/rate/delete/{doctorId}")]
    public async Task<IActionResult> DeleteDoctorRating(string doctorId)
    {
        var command = new DeleteDoctorRateCommand(doctorId, GetUserIdFromToken());
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/popuplar")]
    public async Task<IActionResult> GetPopularDoctors(string? specialization)
    {
        var query = new GetPopularDoctorsQuery(specialization!);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/{doctorId}/doctor-rates/page-number/{pageNumber}")]
    public async Task<IActionResult> GetDoctorRates(string doctorId, int pageNumber)
    {
        var query = new GetDoctorRatesByDoctorIdQuery(
            doctorId,
            pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("doctor/update-price-per-session")]
    public async Task<IActionResult> UpdatePricePerSession(UpdatePricePerSessionRequest request)
    {
        var command = new UpdatePricePerSessionCommand(
            GetUserIdFromToken(), 
            request.price);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

}