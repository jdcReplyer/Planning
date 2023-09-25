using AutoMapper;
using Common.Messaging.Services.Interfaces;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Planning.Business.Entities;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Output;

namespace Planning.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MasterdataController : BaseController
    {
        private readonly ILogger<MasterdataController> _logger;
        private IUserService _userService;
        private IMasterdataService _masterdataService;
        
        public MasterdataController(
            ILogger<MasterdataController> logger,
            IUserService userService,
            IMasterdataService masterdataService) : base(userService)
        {
            _userService = userService;
            _logger = _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _masterdataService = masterdataService ?? throw new ArgumentNullException(nameof(masterdataService));
        }

        [HttpGet("GetDeposits")]
        public async Task<ActionResult> GetDeposits()
        {
            return Ok(await _masterdataService.GetDeposits());
        }


        [HttpGet("GetPartners")]
        public async Task<ActionResult> GetPartners()
        {
            
            return Ok(await _masterdataService.GetPartners());
        }

        [HttpGet("GetCarriers")]
        public async Task<ActionResult> GetCarriers()
        {

            return Ok(await _masterdataService.GetCarriers());
        }

        [HttpGet("GetEquipment")]
        public async Task<ActionResult> GetEquipments()
        {

            return Ok(await _masterdataService.GetEquipments());
        }


    }
}