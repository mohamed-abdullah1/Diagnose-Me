using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers;


[Route("api/v1")]

public class MedicalServicesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public MedicalServicesController(ISender mediator, 
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
}