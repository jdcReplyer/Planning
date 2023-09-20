using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Output;
using Planning.DataAccess.Repositories.Implementations;
using Planning.Models;

namespace Planning.Business.Services.Implementations
{
    public class OrderService: IOrderService
    {
        readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            return MockDTO.GetOrdersDto();
        }

    }
}
