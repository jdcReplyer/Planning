using Planning.Common;
using Planning.Models;



namespace Planning.DataAccess.Repositories.Implementations
{
    public interface ITripRepository
    {
        Task Insert(Guid id);
        Task Update(Guid id, AlgorithmCallStatusEnum status, string? log);
        Task<IEnumerable<Trip>> GetAll();
    }
}