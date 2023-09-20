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
	public class PlanningController : BaseController
	{
        private readonly ILogger<PlanningController> _logger;
        private IUserService _userService;
        private ITripService _tripService;
        private IOrderService _orderService;
		public PlanningController(
                                         ILogger<PlanningController> logger,
                                         IUserService userService,
                                         ITripService tripService,
                                         IOrderService orderService) : base(userService)
        {
            _userService = userService;
            _logger = _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tripService = tripService ?? throw new ArgumentNullException(nameof(tripService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("Trip/GetAll")]
        public async Task<ActionResult> GetTrip()
        {
            var trips = await _tripService.GetAll();
            return Ok(trips);
        }


        [HttpGet("Order/GetOrders")]
        public async Task<ActionResult> GetOrders(string? department, string? bft, string? group, string? date, bool? sent)
        {
            Console.WriteLine($"Department is {department}");
            Console.WriteLine($"Bft is {bft}");
            Console.WriteLine($"Group is {group}");
            Console.WriteLine($"Date is {date}");
            Console.WriteLine($"Sent is {sent}");
            return Ok(await _orderService.GetOrders());
        }


    }
}
