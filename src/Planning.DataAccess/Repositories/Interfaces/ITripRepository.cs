using Planning.Common;
using Planning.Models;



namespace Planning.DataAccess.Repositories.Implementations
{
    public interface ITripRepository
    {
        Task Insert(Guid id);
        Task<IEnumerable<Trip>> GetAll();
    }
}