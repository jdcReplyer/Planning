using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middlewares.Exceptions
{
    public class GroupNotFoundException : Exception
    {
        public GroupNotFoundException(int groupId) : base($"Group with Id '{groupId}' not found!")
        {
        }
    }
}
