using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middlewares.Exceptions
{
    public class OrderNotFoundException: Exception
    {
        public OrderNotFoundException(long orderId) : base($"Order with Id '{orderId}' not found!")
        {
        }
    }
}
