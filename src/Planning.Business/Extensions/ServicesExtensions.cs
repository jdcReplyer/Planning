using Common.Constants;
using Common.Services.Implementations;
using Common.Services.Interfaces;
using Common.Services.ServicesExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Planning.Business.Services.Implementations;
using Planning.Business.Services.Interfaces;
using Planning.Common;
using Planning.DataAccess.DbContexts;
using Planning.DataAccess.Repositories.Implementations;


namespace Planning.Business.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {

            services
              .AddDbContext<PlanningDbContext>(options =>
              {
                  options.UseSqlServer(configuration.GetConnectionString(Constants.CONNECTION_STRING_KEY_NAME),
                      sqlServerOptions =>
                      {
                          sqlServerOptions
                              .MigrationsAssembly(Constants.DATA_ACCESS_PROJ_NAME)
                              .MigrationsHistoryTable(DatabaseConstants.EFIGRATIONHISTORY_TABLE_NAME, configuration[DatabaseConstants.SCHEMA_KEY_NAME]);
                      });
              });
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            //services

            // Services

            services.AddTransient<ITripService, TripService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IMasterdataService, MasterdataService>();
            services.AddTransient<IGroupService, GroupsService>();


            // Repositories

            services.AddScoped<ITripRepository, TripRepository>()




                // Automapper Resolvers

                // Integration Event Handlers

                //.AddTransient<UploadedReportRiskImportantDocsIntegrationEventHandler>()

                // Common
                .AddCommonDateTimeServices()
                .AddCommonUserServices()
                ;

        }

        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PlanningDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
