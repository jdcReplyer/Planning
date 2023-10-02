using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Planning.API.ModelValidation;
using Planning.Business.Services.Interfaces;

namespace Planning.API.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : BaseController
    {
        private readonly ILogger<GroupController> _logger;
        private IUserService _userService;
        private IGroupService _groupService;
        public GroupController(
            ILogger<GroupController> logger,
            IUserService userService,
            IGroupService groupService) : base(userService)
        {
            _userService = userService;
            _logger = _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _groupService = groupService;
        }

        [HttpGet("GetGroups")]
        public async Task<ActionResult> GetGroups([FromQuery] GetGroupsModelValidation parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(await _groupService.GetGroups(parameters.Bft, parameters.Department));
        }

        [HttpGet("GetMyGroups")]
        public async Task<ActionResult> GetMyGroups()
        {

            return Ok(await _groupService.GetMyGroups());
        }

        [HttpPost("PostTakeChargeGroups")]
        public async Task<ActionResult> PostTakeChargeGroups([FromQuery] List<int> ids)
        {

            return Ok(await _groupService.PostTakeChargeGroups(ids));
        }

        [HttpPost("SubmitGroups")]
        public async Task<ActionResult> SubmitGroups([FromQuery] List<int> ids)
        {
            await _groupService.SubmitGroups(ids);
            return Ok();
        }


    }




}
