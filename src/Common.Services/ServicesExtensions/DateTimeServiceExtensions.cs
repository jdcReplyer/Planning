using Common.Services.Implementations;
using Common.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Services.ServicesExtensions
{
    public static class DateTimeServiceExtensions
    {
        public static IServiceCollection AddCommonDateTimeServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
