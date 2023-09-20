namespace Common.Services.Interfaces
{
    public interface IDateTimeService
    {
        public DateTime GetNow();
        public DateTime GetUtcNow();
    }
}
