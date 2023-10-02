using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middlewares.Exceptions
{
    public class UnauthorizedCreateTrip: Exception
    {
        public UnauthorizedCreateTrip(long orderId) : base($"Cannot create a trip with order {orderId}"){}
    }
}
