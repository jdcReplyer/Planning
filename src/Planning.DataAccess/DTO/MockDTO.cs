using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataAccess.DTO.Output;

namespace Planning.DataAccess.DTO
{
    public static class MockDTO
    {
        public static List<OrderDTO> GetOrdersDto()
        {
            var origin = new LocationDTO
            {
                CountryISO = "IT",
                LocationName = "Dayco Europe",
                Address = "1006 San Bernardo",
                Hall = "123",
                Plant = "abc"
            };

            var destination = new LocationDTO
            {
                CountryISO = "DE",
                LocationName = "MAN",
                Address = "38239 Salzgitter",
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
                ShippingUnitDetails = shippingUnitDetails,
                Origin = origin,
                Destination = origin
            };

            return new List<OrderDTO>(){order};

        }
    }
}
