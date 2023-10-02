using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User? ChargedUser { get; set; }

        public string BusinessFlowType { get; set; }
        public string Department { get; set; }

        public string Status { get; set; }
    }
}
