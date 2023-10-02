using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Middlewares.Exceptions;
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

        public async Task<IEnumerable<OrderDTO>> GetMyOrders()
        {
            return MockDTO.Orders.FindAll(o => o.Group.ChargedUser?.Id == 1);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders(List<int> groupIds, DateTime? datetime, bool? sent)
        {
            
            var groups =  MockDTO.Orders.FindAll(o => groupIds.Contains(o.Group.Id) && datetime?.CompareTo(o.PickupDateTime) <= 0);
            return groups;
        }

        public async Task<IEnumerable<OrderDTO>> GetOriginalOrders(List<long> orderIds)
        {
            return MockDTO.OriginalOrders.FindAll(o => orderIds.Contains(o.Id));
        }

        public async Task<int> UpdateOrders(List<OrderDTO> updatedOrders)
        {
            var ids = updatedOrders.Select(o => o.Id);
            foreach (var order in MockDTO.Orders)
            {
                if (ids.Contains(order.Id) && order.Group.ChargedUser?.Id != 1)
                {
                    throw new UnauthorizedUpdateOrderException(order.Id);
                }
            }

            var allIds = MockDTO.Orders.Select(o => o.Id);
            foreach (var uo in updatedOrders)
            {
                if (!allIds.Contains(uo.Id))
                {
                    throw new OrderNotFoundException(uo.Id);
                }
            }

            foreach (var uo in updatedOrders)
            {
                var order = MockDTO.Orders.Find(o => o.Id == uo.Id);
                order.Planning = uo.Planning;
                order.LinearMeters = uo.LinearMeters;

            }



            return 0;


        }
    }

}
