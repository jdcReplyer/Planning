using Planning.Models;

namespace Planning.Business.Services.Interfaces;

public interface ITripService
{
    Task<IEnumerable<Trip>> GetAll();
}