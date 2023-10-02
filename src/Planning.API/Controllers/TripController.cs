using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Planning.Business.Services.Interfaces;

namespace Planning.API.Controllers
{
    public class TripController: BaseController
    {
        private readonly ILogger<TripController> _logger;
        private IUserService _userService;
        private ITripService _tripService;

        public TripController(
            ILogger<TripController> logger,
            IUserService userService,
            ITripService tripService) : base(userService)
        {
            _userService = userService;
            _logger = _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tripService = tripService;
        }


        [HttpGet("Trip/GetAll")]
        public async Task<ActionResult> GetTrip()
        {
            var trips = await _tripService.GetAll();
            return Ok(trips);
        }
    }
}
