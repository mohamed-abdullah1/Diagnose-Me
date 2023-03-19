using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class HealthCheckController : ApiController
{
    public HealthCheckController(Serilog.ILogger logger) : base(logger)
    {
    }
    [AllowAnonymous]
    [HttpGet("health-check")]
    public ActionResult HealthCheck()
    {
        var nameIdentifier = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        return Ok(nameIdentifier);
    }
}