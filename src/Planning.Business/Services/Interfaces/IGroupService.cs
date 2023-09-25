using Planning.DataAccess.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Business.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetGroups(string bft, string department);
        Task<IEnumerable<GroupDTO>> GetMyGroups();
        Task<IEnumerable<GroupPostOutcomeDTO>> PostTakeChargeGroups(List<int> ids);
        Task<int> SubmitGroups(List<int> ids);





    }

}
