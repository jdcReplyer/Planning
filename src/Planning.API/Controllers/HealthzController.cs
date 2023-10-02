using Microsoft.AspNetCore.Mvc;
using Planning.DataAccess.DTO;

namespace Planning.API.Controllers
{

    [ApiController]
    [Route("_healthz")]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            MockDTO.LogGroups.ForEach(g => Console.WriteLine(g));
            return Ok("alive");
        }
    }
}
