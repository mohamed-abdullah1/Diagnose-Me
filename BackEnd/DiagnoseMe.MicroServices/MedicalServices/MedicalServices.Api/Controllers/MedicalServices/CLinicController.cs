using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinic;
using MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;
using MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinic;
using MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinicAddress;
using MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinic;
using MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddress;
using MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddressProfilePicture;
using MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicPicture;
using MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicAdresses;
using MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicDoctors;
using MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinics;
using MedicalServices.Contracts.Clinics;
using MedicalServices.Domain.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers.MedicalServices;


[Route("api/v1")]
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
    [HttpGet("clinics/page-number/{pageNumber}")]
    public async Task<IActionResult> GetClinics(int pageNumber)
    {

        var query = new GetClinicsQuery(pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }
    
    [Authorize]
    [HttpGet("clinics/{clinicId}/addresses/page-number/{pageNumber}")]
    public async Task<IActionResult> GetClinicsAddresses(int pageNumber,string clinicId)
    {

        var query = new GetClinicAddressesQuery(clinicId,pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize]
    [HttpGet("clinics/{clinicId}/doctors/page-number/{pageNumber}")]
    public async Task<IActionResult> GetClinicsDoctors(int pageNumber,string clinicId)
    {

        var query = new GetClinicDoctorsQuery(clinicId,pageNumber);
        var result = await _mediator.Send(query);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("clinics/add")]
    public async Task<IActionResult> AddClinic(AddClinicRequest request)
    {
        var command = _mapper.Map<AddClinicCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }


    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("clinics/{clinicId}/delete")]
    public async Task<IActionResult> DeleteClinic(string clinicId)
    {
        var command = new DeleteClinicCommand(clinicId);
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("clinics/{clinicId}/update")]
    public async Task<IActionResult> UpdateClinic(string clinicId,UpdateClinicRequest request)
    {
        var command = new UpdateClinicCommand(
            clinicId,
            request.Description);
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("clinics/{clinicId}/update-picture")]
    public async Task<IActionResult> UpdateClinicPicture(string clinicId,UpdateClinicPictureRequest request)
    {
        var command = new UpdateClinicPictureCommand(
            clinicId,
            request.Base64Picture);
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("clinics/{clinicId}/addresses/add")]
    public async Task<IActionResult> AddClinicAddress(string clinicId,AddClinicAddressRequest request)
    {
        var command = _mapper.Map<AddClinicAddressCommand>((request,GetUserIdFromToken()));
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpDelete("clinics/{clinicId}/addresses/{address-id}/delete")]
    public async Task<IActionResult> DeleteClinicAddress(string clinicId,string addressId)
    {
        var command = new DeleteClinicAddressCommand(addressId, GetUserIdFromToken());
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("clinics/{clinicId}/addresses/{address-id}/update")]
    public async Task<IActionResult> UpdateClinicAddress(string clinicId,string addressId,UpdateClinicAddressRequest request)
    {
        var command = _mapper.Map<UpdateClinicAddressCommand>((request,GetUserIdFromToken()));
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost("clinics/{clinicId}/addresses/address-id/{addressId}/update-picture")]
    public async Task<IActionResult> UpdateClinicAddressProfilePicture(string clinicId,string addressId,UpdateClinicAddressProfilePictureRequest request)
    {
        var command = new UpdateClinicAddressProfilePictureCommand(
            addressId,
            request.Base64Picture,
            GetUserIdFromToken());
        
        var result = await _mediator.Send(command);
        return result.Match(
        result => Ok(result),
        errors => Problem(errors));
    }

}