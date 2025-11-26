using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers;

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
            service = "UserService",
            time = DateTime.UtcNow
        };

        return Ok(response);
    }
}