using Common.Services.Implementations;
using Common.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Services.ServicesExtensions
{
    public static class UserServiceExtensions
    {
        public static IServiceCollection AddCommonUserServices(this IServiceCollection services)
        {
            return services
                .AddHttpContextAccessor()
                .AddTransient<IUserService, UserService>();
        }
    }
}
