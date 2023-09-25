using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Output;

namespace Planning.Business.Services.Implementations
{
    public class MasterdataService: IMasterdataService
    {
        readonly ILogger<MasterdataService> _logger;

        public MasterdataService(ILogger<MasterdataService> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<IEnumerable<CarrierDTO>> GetCarriers()
        {
            return MockDTO.GetCarrierDtos();
        }

        public async Task<IEnumerable<DepositDTO>> GetDeposits()
        {
            return MockDTO.GetDepositDtos();
        }

        public async Task<IEnumerable<EquipmentDTO>> GetEquipments()
        {
            return MockDTO.GetEquipmentDtos();
        }

        public async Task<IEnumerable<PartnerDTO>> GetPartners()
        {
            return MockDTO.GetPartnerDtos();
        }
    }
}
