using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Common;

namespace Planning.DataAccess.DTO.Output
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkProgress { get; set; }
        public ChargedUser? ChargedUser { get; set; }
        public BusinessFlowType BusinessFlowType { get; set; }
        public Department Department { get; set; }

        public Status Status { get; set; }

        public string OriginZip { get; set; }
        public string DestinationZip { get; set; }

        
       
    }

    public class Department
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class Status
    {
        public StatusGroup Id { get; set; }
        public string Name { get; set; }
    }

    public class BusinessFlowType
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class ChargedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Datetime { get; set; }
    }
}
