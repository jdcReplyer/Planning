using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middlewares.Exceptions
{
    public class SubmitGroupException: Exception
    {
        public SubmitGroupException(string groupName) : base($"You cannot submit group '{groupName}'!")
        {
        }
    }
}
