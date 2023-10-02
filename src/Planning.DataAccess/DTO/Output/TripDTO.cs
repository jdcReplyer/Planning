using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataAccess.DTO.Output
{
    public class TripDTO
    {
        public string Equipment { get; set; }

        public List<OrderDTO> Orders { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
    }
}
