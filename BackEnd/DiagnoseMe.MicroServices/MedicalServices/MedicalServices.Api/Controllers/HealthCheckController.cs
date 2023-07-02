using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Api.Controllers;


public class HealthCheckController : ApiController
{
    public HealthCheckController(Serilog.ILogger logger) : base(logger)
    {
    }
    [AllowAnonymous]
    [HttpGet("health-check")]
    public ActionResult HealthCheck()
    {
        return Ok(true);
    }
}