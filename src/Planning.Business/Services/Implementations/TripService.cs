using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Middlewares.Exceptions;
using Microsoft.Extensions.Logging;
using Planning.Business.Services.Interfaces;
using Planning.DataAccess.DTO;
using Planning.DataAccess.DTO.Input;
using Planning.DataAccess.DTO.Output;
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

        public async Task<int> CreateTrip(CreateTripDTO trip)
        {
            var orders = MockDTO.Orders.FindAll(o => trip.Orders.Contains(o.Id));
            foreach (var o in orders)
            {
                if (o.Group.ChargedUser == null || o.Group.ChargedUser.Id != 1)
                {
                    throw new UnauthorizedCreateTrip(o.Id);
                }   
            }
            orders.ForEach(o => o.Planning.ForEach(o => o.TripId = MockDTO.Trips.Count));
            MockDTO.Trips.Add(new TripDTO
            {
                Id = MockDTO.Trips.Count,
                Description = trip.Description,
                Equipment = trip.Equipment,
                Orders = MockDTO.Orders.FindAll(o => trip.Orders.Contains(o.Id)),
            });
            return 0;
        }

        public async Task<IEnumerable<TripDTO>> GetAll()
        {
            return MockDTO.Trips;
        }
    }   
}
