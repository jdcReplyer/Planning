using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

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
        public List<PlanningDTO> SuggestedPlanning { get; set; }
        public int LinearMeters { get; set; }
        public string LinearMetersType { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int ShippingUnit { get; set; }
        public List<ShippingUnitDTO> ShippingUnitDetails { get; set; }
        public int TaxWeight { get; set; }
        public int Volume { get; set; }
        public int Weight { get; set; }
        public int AggregationId { get; set; }
        public GroupDTO Group { get; set; }

        public static OrderDTO Mock()
        {
            var origin = new LocationDTO
            {
                CountryISO = "IT",
                LocationName = "Dayco Europe",
                Address = "1006 San Bernardo",
                Zip = "1006",
                Hall = "123",
                Plant = "abc"
            };

            var destination = new LocationDTO
            {
                CountryISO = "DE",
                LocationName = "MAN",
                Address = "38239 Salzgitter",
                Zip = "38239",
                Hall = null,
                Plant = "abc"
            };

            var planning = new List<PlanningDTO>()
            {
                new PlanningDTO{
                    Type = "Leg",
                    DepositName = null,
                    TripId = null,
                    CountryISO = "IT",
                    InStandBy = false,
                    ForwardedToNetwork = false
                }
            };

            

            var shippingUnitDetails = new List<ShippingUnitDTO>()
            {
                new ShippingUnitDTO
                {
                    Quantity = 6,
                    PackageValue = "111444",
                    Stackability = 2,
                    Width = 10,
                    Lenght = 10,
                    Height = 10
                },
                new ShippingUnitDTO
                {
                    Quantity = 4,
                    PackageValue = "VWPAL",
                    Stackability = 2,
                    Width = 10,
                    Lenght = 10,
                    Height = 10
                },
                new ShippingUnitDTO
                {
                    Quantity = 1,
                    PackageValue = "000PAL",
                    Stackability = 2,
                    Width = 10,
                    Lenght = 10,
                    Height = 10
                }

            };


            var order = new OrderDTO
            {
                Id = 1,
                Number = 1,
                PartnerToDeliver = null,
                LinearMeters = 10,
                LinearMetersType = "M",
                PickupDateTime = new DateTime(2023, 06, 29, 10, 44, 20),
                DeliveryDateTime = new DateTime(2023, 06, 29, 10, 44, 20),
                ShippingUnit = 10,
                TaxWeight = 1000,
                Volume = 40,
                Weight = 1000,
                Planning = planning,
                SuggestedPlanning = planning.ConvertAll(o => o),
                ShippingUnitDetails = shippingUnitDetails,
                Origin = origin,
                Destination = origin,
                AggregationId = 1,
                Group = null
            };

            return order;

        }

        public List<GroupDTO> DetermineGroups(List<GroupDTO> groups)
        {
            var res = new List<GroupDTO>();
            
            foreach (var g in groups)
            {
                var zipStart = "";
                var zipEnd = "";

                for (int i = -1; i < this.Planning.Count - 1; i++)
                {
                    if (i == -1)
                    {
                        zipStart = this.Origin.Zip;
                        
                    } else if (i == this.Planning.Count-2)
                    {
                        zipStart = this.Origin.Zip;
                        zipEnd = this.Destination.Zip;
                    }
                }
                if (g.OriginZip == zipStart && g.DestinationZip == zipEnd)
                {
                    res.Add(g);
                }


            }
            return res;
        }
    }

    
}
