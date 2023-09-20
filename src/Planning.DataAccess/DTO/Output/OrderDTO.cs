using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataAccess.DTO.Output
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string? PartnerToDeliver { get; set; }
        public LocationDTO Origin { get; set; }
        public LocationDTO Destination { get; set; }
        public List<PlanningDTO> Planning { get; set; }
        public int LinearMeters { get; set; }
        public string LinearMetersType { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int ShippingUnit { get; set; }
        public List<ShippingUnitDTO> ShippingUnitDetails { get; set; }
        public int TaxWeight { get; set; }
        public int Volume { get; set; }
        public int Weight { get; set; }

    }
}
