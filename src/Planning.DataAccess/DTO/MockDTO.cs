using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Common;
using Planning.DataAccess.DTO.Output;

namespace Planning.DataAccess.DTO
{
    public static class MockDTO
    {
        public static List<GroupDTO> Groups = GeneratesGroupDtos();

        public static List<OrderDTO> GetOrderDtos()
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

        public static List<DepositDTO> GetDepositDtos()
        {
            var addressDTO = new AddressDTO
            {
                Address = "Via Roma 1",
                City = "Milano",
                Zip = "00000"
            };
            var depositDTO = new DepositDTO
            {
                Id = 1,
                Name = "DCT",
                Address = addressDTO
            };

            return new List<DepositDTO>() { depositDTO };
        }

        public static List<PartnerDTO> GetPartnerDtos()
        {
            var addressDTO = new AddressDTO
            {
                Address = "Via Roma 1",
                City = "Milano",
                Zip = "00000"
            };
            var partnerDto = new PartnerDTO
            {
                Id = 1,
                Name = "Partner Lorem Ipsum",
                Address = addressDTO
            };

            return new List<PartnerDTO>() { partnerDto };
        }

        public static List<CarrierDTO> GetCarrierDtos()
        {
            
            var carrierDto = new CarrierDTO
            {
                Id = 1,
                Name = "Vettore 1",
            };

            return new List<CarrierDTO>() { carrierDto };
        }

        public static List<EquipmentDTO> GetEquipmentDtos()
        {

            var equipmentDto = new EquipmentDTO
            {
                Id = 1,
                Name = "Equipment Mock",
                Volume = 100
            };

            return new List<EquipmentDTO>() { equipmentDto };
        }

        public static List<GroupDTO> GeneratesGroupDtos()
        {
            var group1 = new GroupDTO
            {
                Id = 1,
                Name = "Export 1",
                BusinessFlowType = new BusinessFlowType
                {
                    Code = "inbound_returns",
                    Name = "Inbound returns"
                },
                ChargedUser = null,
                Department = new Department
                {
                    Code = "international",
                    Name = "International"
                },
                Status = new Status
                {
                    Id = StatusGroup.CONFIRMED_BY,
                    Name = "Confirmed By"
                },
                WorkProgress = "100m\u00b3/1000m\u00b3"
            };

            var group2 = new GroupDTO
            {
                Id = 2,
                Name = "Export 2",
                BusinessFlowType = new BusinessFlowType
                {
                    Code = "inbound_returns",
                    Name = "Inbound returns"
                },
                ChargedUser = null,
                Department = new Department
                {
                    Code = "international",
                    Name = "International"
                },
                Status = new Status
                {
                    Id = StatusGroup.CONFIRMED_BY,
                    Name = "Confirmed By"
                },
                WorkProgress = "100m\u00b3/1000m\u00b3"
            };

            return new List<GroupDTO>() { group1, group2 };
        }

        



    }
}