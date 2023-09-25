using Planning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataAccess.DTO.Output;

namespace Planning.Business.Services.Interfaces
{
    public interface IMasterdataService
    {
        Task<IEnumerable<DepositDTO>> GetDeposits();
        Task<IEnumerable<PartnerDTO>> GetPartners();
        Task<IEnumerable<CarrierDTO>> GetCarriers();
        Task<IEnumerable<EquipmentDTO>> GetEquipments();


    }
}
