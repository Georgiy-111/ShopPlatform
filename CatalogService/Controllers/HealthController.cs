using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var response = new
        {
            status = "OK",
            service = "CatalogService",
            time = DateTime.UtcNow
        };

        return Ok(response);
    }
}