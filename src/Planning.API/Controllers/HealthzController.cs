using Microsoft.AspNetCore.Mvc;

namespace Planning.API.Controllers
{

    [ApiController]
    [Route("_healthz")]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("alive");
        }
    }
}
