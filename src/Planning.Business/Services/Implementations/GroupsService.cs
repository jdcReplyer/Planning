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
using Planning.Models;

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
            return MockDTO.Groups.FindAll(g => g.BusinessFlowType.Code == bft && g.Department.Code == department && g.ChargedUser?.Id != 1);
        }

        public async Task<IEnumerable<GroupDTO>> GetMyGroups()
        {
            return MockDTO.Groups.FindAll(g => g.ChargedUser?.Id == 1);
        }

       

        public async Task<IEnumerable<GroupPostOutcomeDTO>> PostTakeChargeGroups(List<int> ids)
        {
            var groups = MockDTO.Groups.FindAll(g => ids.Contains(g.Id));

            foreach (var id in ids)
            {
                if (!groups.Any(g => g.Id == id))
                {
                    throw new GroupNotFoundException(id);
                }
            }
            var postGroups = new List<GroupPostOutcomeDTO>();
            foreach (var g in groups)
            {
                var success = false;
                if (g.Status.Id == StatusGroup.TO_BE_PLANNED)
                {
                    g.ChargedUser = new ChargedUser
                    {
                        Id = 1,
                        Name = "Enrico",
                        Surname = "Paolazzi",
                        Datetime = DateTime.Now
                    };
                    success = true;

                    MockDTO.LogGroups.Add(new LogGroup
                    {
                        Id = MockDTO.LogGroups.Count,
                        Action = ActionGroup.TAKE_CHARGE,
                        Datetime = DateTime.Now,
                        User = 1,
                        Group = g.Id
                    });
                    g.Status.Id = StatusGroup.IN_CHARGE_OF;
                    g.Status.Name = "In charge of";
                }

                postGroups.Add(new GroupPostOutcomeDTO { Success = success, Group = g });
            }

            return postGroups;
        }

        public async Task<int> SubmitGroups(List<int> ids)
        {
            var groups = MockDTO.Groups.FindAll(g => ids.Contains(g.Id));
            
            foreach (var id in ids)
            {
                if (!groups.Any(g => g.Id == id))
                {
                    throw new GroupNotFoundException(id);
                }
            }

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
                    Id = StatusGroup.CONFIRMED_BY,
                    Name = "Confirmed by"
                };

                MockDTO.LogGroups.Add(new LogGroup
                {
                    Id = MockDTO.LogGroups.Count,
                    Action = ActionGroup.SUBMIT,
                    Datetime = DateTime.Now,
                    User = 1,
                    Group = g.Id
                });
            }

            return 0;
        }

        
    }

}
