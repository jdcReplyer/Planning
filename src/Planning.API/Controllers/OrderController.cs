using AutoMapper;
using Common.Messaging.Services.Interfaces;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Planning.API.ModelValidation;
using Planning.Business.Entities;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Output;

namespace Planning.API.Controllers
{

    [ApiController]
	[Route("api/[controller]")]
	public class OrderController : BaseController
	{
        private readonly ILogger<OrderController> _logger;
        private IUserService _userService;
        private IOrderService _orderService;
        private ITripService _tripService;
		public OrderController(
                                         ILogger<OrderController> logger,
                                         IUserService userService,
                                         IOrderService orderService,
                                         ITripService tripService) : base(userService)
        {
            _userService = userService;
            _logger = _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _tripService = tripService;

        }

        





        [HttpGet("GetOrders")]
        public async Task<ActionResult> GetOrders([FromQuery] GetOrdersModelValidation parameters)
        {
            Console.WriteLine($"Groups are {parameters.groups}");
            Console.WriteLine($"Date is {parameters.date}");
            Console.WriteLine($"Sent is {parameters.sent}");
            return Ok(await _orderService.GetOrders(parameters.groups, parameters.date, parameters.sent));
        }

        [HttpGet("GetMyOrders")]
        public async Task<ActionResult> GetMyOrders()
        {
           
            return Ok(await _orderService.GetMyOrders());
        }

        [HttpPut("UpdateOrders")]
        public async Task<ActionResult> UpdateOrders([FromBody] List<OrderDTO> updatedOrders)
        {
            await _orderService.UpdateOrders(updatedOrders);
            return Ok();
        }

        [HttpGet("GetOriginalOrders")]
        public async Task<ActionResult> GetOriginalOrders([FromQuery] List<long> ids)
        {

            return Ok(await _orderService.GetOriginalOrders(ids));
        }


    }
}
