namespace Common.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserUniqueNameFromContext();
    }
}
