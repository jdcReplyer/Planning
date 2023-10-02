using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataAccess.DTO.Output;

namespace Planning.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders(List<int> groupIds, DateTime? datetime, bool? sent);
        Task<IEnumerable<OrderDTO>> GetMyOrders();
        Task<int> UpdateOrders(List<OrderDTO> updatedOrders);
        Task<IEnumerable<OrderDTO>> GetOriginalOrders(List<long> groupIds);



    }
}
