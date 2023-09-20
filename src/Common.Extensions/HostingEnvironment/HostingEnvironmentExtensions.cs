using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Common.Extensions.HostingEnvironment
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsLocal(this IWebHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsEnvironment("Local");
        }

        public static bool IsPreProduction(this IWebHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsEnvironment("PreProduction");
        }

        public static bool IsLocalOrDevelopment(this IWebHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsLocal() || hostingEnvironment.IsDevelopment();
        }
    }
}
