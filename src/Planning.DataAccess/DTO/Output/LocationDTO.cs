using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataAccess.DTO.Output
{
    public class LocationDTO
    {
        public string CountryISO { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string? Hall { get; set; }
        public string Plant { get; set; }

        public string Zip { get; set; }

        
    }

}
