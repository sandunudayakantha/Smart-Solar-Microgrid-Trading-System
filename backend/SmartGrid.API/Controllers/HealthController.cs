/*
 * File Name    : HealthController.cs
 * Description  : Provides a simple endpoint to check if the API is running correctly.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-16
 */

using Microsoft.AspNetCore.Mvc;

namespace SmartGrid.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        // Returns a simple JSON response indicating the API status.
        [HttpGet]
        public IActionResult GetStatus()
        {
            // Return HTTP 200 OK with a success message
            return Ok(new
            {
                Success = true,
                Message = "Smart Solar Microgrid API is running.",
                Timestamp = System.DateTime.UtcNow
            });
        }
    }
}
