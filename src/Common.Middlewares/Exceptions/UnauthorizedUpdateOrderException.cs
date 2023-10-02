using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middlewares.Exceptions
{
    public class UnauthorizedUpdateOrderException : Exception
    {
        public UnauthorizedUpdateOrderException(long orderId) : base($"You cannot update order '{orderId}'!")
        {
        }
    }
}
