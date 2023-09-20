using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.Repositories.Implementations;
using Planning.Models;

namespace Planning.Business.Services.Implementations
{
    public class TripService: ITripService
    {
        readonly ITripRepository _tripRepository;
        readonly ILogger<TripService> _logger;

        public TripService(ITripRepository tripRepository, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository ?? throw new ArgumentException(nameof(TripRepository));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _tripRepository.GetAll();
        }
    }   
}
