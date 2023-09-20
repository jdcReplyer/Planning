using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataAccess.DTO.Output
{
    public class ShippingUnitDTO
    {
        public int Quantity { get; set; }
        public string PackageValue { get; set; }
        public int Stackability { get; set; }
        public int Width { get; set; }
        public int Lenght { get; set; }
        public int Height { get; set; }
    }
}
