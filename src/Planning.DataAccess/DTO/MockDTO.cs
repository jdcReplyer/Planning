using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Common;
using Planning.DataAccess.DTO.Output;
using Planning.Models;

namespace Planning.DataAccess.DTO
{
    public static class MockDTO
    {
        public static List<GroupDTO> Groups = GeneratesGroupDtos();
        public static List<LogGroup> LogGroups = new List<LogGroup>();
        public static List<OrderDTO> Orders = GetOrderDtos();
        public static List<OrderDTO> OriginalOrders = GetOrderDtos();
        public static List<TripDTO> Trips = new List<TripDTO>();





        public static List<OrderDTO> GetOrderDtos()
        {
            var order1 = OrderDTO.Mock();
            order1.Id = 1;
            order1.Group = (Groups.First());
            var order2 = OrderDTO.Mock();
            order2.Id = 2;
            order2.Group = (Groups.First());
            var order3 = OrderDTO.Mock();
            order3.Id = 3;
            order3.Group = (Groups.Last());
            var order4 = OrderDTO.Mock();
            order4.Id = 4;
            order4.Group = (Groups.Last());



            return new List<OrderDTO>(){order1, order2, order3, order4};

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
                    Id = StatusGroup.TO_BE_PLANNED,
                    Name = "None"
                },
                WorkProgress = "100m\u00b3/1000m\u00b3",
                OriginZip = "1006",
                DestinationZip = "38239",
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
                    Id = StatusGroup.TO_BE_PLANNED,
                    Name = "None"
                },
                WorkProgress = "100m\u00b3/1000m\u00b3",
                OriginZip = "1006",
                DestinationZip = "38239",
            };

            return new List<GroupDTO>() { group1, group2 };
        }

        



    }
}