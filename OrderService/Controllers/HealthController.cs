using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

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
            service = "OrderService",
            time = DateTime.UtcNow
        };

        return Ok(response);
    }
}