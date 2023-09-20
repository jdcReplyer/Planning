using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataAccess.DTO.Output
{
    public class PlanningDTO
    {
        public string Type { get; set; }
        public string? DepositName { get; set; }
        public long? TripId { get; set; }
        public string CountryISO { get; set; }
        public bool InStandBy { get; set; }
        public bool ForwardedToNetwork { get; set; }



    }
}
