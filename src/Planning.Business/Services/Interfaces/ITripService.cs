using Planning.DataAccess.DTO.Input;
using Planning.DataAccess.DTO.Output;
using Planning.Models;

namespace Planning.Business.Services.Interfaces;

public interface ITripService
{
    Task<IEnumerable<TripDTO>> GetAll();
    Task<int> CreateTrip(CreateTripDTO trip);
}