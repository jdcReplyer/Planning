using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Middlewares.Exceptions;
using Planning.Business.Services.Interfaces;
using Planning.Common;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Output;

namespace Planning.Business.Services.Implementations
{
    public class GroupsService: IGroupService
    {
        readonly ILogger<GroupsService> _logger;

        public GroupsService(ILogger<GroupsService> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<IEnumerable<GroupDTO>> GetGroups(string? bft, string? department)
        {
            return MockDTO.Groups.FindAll(g => g.BusinessFlowType.Code == bft && g.Department.Code == department && g.ChargedUser == null);
        }

        public async Task<IEnumerable<GroupDTO>> GetMyGroups()
        {
            return MockDTO.Groups.FindAll(g => g.ChargedUser?.Id == 1);
        }

       

        public async Task<IEnumerable<GroupPostOutcomeDTO>> PostTakeChargeGroups(List<int> ids)
        {
            var groups = MockDTO.Groups.FindAll(g => ids.Contains(g.Id));
            var postGroups = new List<GroupPostOutcomeDTO>();
            foreach (var g in groups)
            {
                var success = false;
                if (g.ChargedUser == null && g.Status.Id != StatusGroup.SUBMITTED_BY)
                {
                    g.ChargedUser = new ChargedUser
                    {
                        Id = 1,
                        Name = "Enrico",
                        Surname = "Paolazzi",
                        Datetime = DateTime.Now
                    };
                    success = true;
                }

                postGroups.Add(new GroupPostOutcomeDTO { Success = success, Group = g });
            }

            return postGroups;
        }

        public async Task<int> SubmitGroups(List<int> ids)
        {
            var groups = MockDTO.Groups.FindAll(g => ids.Contains(g.Id));
            foreach (var g in groups)
            {
                if (g.ChargedUser == null || g.ChargedUser.Id != 1)
                {
                    throw new SubmitGroupException(g.Name);
                }
            }

            foreach (var g in groups)
            {
                g.Status = new Status
                {
                    Id = StatusGroup.SUBMITTED_BY,
                    Name = "Submitted"
                };
                g.ChargedUser = null;


            }

            return 0;
        }

        
    }

}
