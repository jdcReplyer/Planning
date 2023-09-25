using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Planning.Common;
using Planning.DataAccess.DbContexts;
using Planning.Models;

namespace Planning.DataAccess.Repositories.Implementations
{
    public class TripRepository : ITripRepository
    {
        private readonly PlanningDbContext _planningDbContext;
        readonly ILogger<TripRepository> _logger;
        public TripRepository(PlanningDbContext planningDbContext,
            ILogger<TripRepository> logger)
        {
            Console.WriteLine("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            _planningDbContext = planningDbContext ?? throw new ArgumentNullException(nameof(PlanningDbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public Task Insert(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<IEnumerable<Trip>> GetAll()
        {
            try
            {
                _logger.LogInformation("Starting find Trip");

                return await Task.Run(() =>
                {

                    var query = from trip in _planningDbContext.Trip
                        select trip;

                    _logger.LogInformation("Found Trip");
                    var result = query;
                    return result.ToList();
                });

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Enumerable.Empty<Trip>().ToList();
            }
        }
    }
}
