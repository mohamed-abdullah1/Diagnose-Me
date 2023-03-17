using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctor;
using MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctor;
using MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctors;
using MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctorsByPatientId;
using MedicalServices.Contracts.Doctors;
using MedicalServices.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers.MedicalServices;

[Route("api/v1")]
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
    [HttpGet("doctors/page-number/{page-number}")]
    public async Task<IActionResult> GetDoctors(int pageNumber)
    {

        var query = new GetDoctorsQuery(pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/{doctor-id}")]
    public async Task<IActionResult> GetDoctor(string doctorId)
    {

        var query = new GetDoctorQuery(doctorId);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("doctors/patient-id/{patient-id}/page-number/{page-number}")]
    public async Task<IActionResult> GetDoctorsByPatientId(string patientId, int pageNumber)
    {

        var query = new GetDoctorsByPatientIdQuery(patientId, pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    [Authorize(Roles = Roles.Doctor+","+Roles.Admin)]
    [HttpPost("doctors/Add/{user-id?}")]
    public async Task<IActionResult> AddDoctor(AddDoctorRequest request, string userId = null!)
    {
        if (User.IsInRole(Roles.Admin))
        {
            if (string.IsNullOrEmpty(userId))
            {
                var errors = new List<Error>
                {
                    Error.Validation(
                        code: "DoctorController.AddDoctor.UserId",
                        description: "User Id is required for admin")
                };
                return Problem(errors);
            }
        }
        else
        {
            userId = GetUserIdFromToken();
        }
        var command = _mapper.Map<AddDoctorCommand>((request, userId));
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
}