using Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Planning.Common;
using Planning.Models;
using Planning.Models;

namespace Planning.DataAccess.DbContexts
{
    public class PlanningDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public PlanningDbContext(IConfiguration configuration, ILoggerFactory logger, DbContextOptions<PlanningDbContext> options) : base(options)
        {
            this.configuration = configuration;
            this.logger = logger.CreateLogger("DbContext logger");
            

            if (Database.IsSqlServer())
            {
                try
                {
                    string clientId = configuration[ServicePrincipalConstants.SP_CLIENT_ID_KEY];
                    string aadTenantId = configuration[ServicePrincipalConstants.SP_TENANT_ID_KEY];
                    string clientSecretKey = configuration[ServicePrincipalConstants.SP_CLIENT_SECRET_KEY];

                    string AadInstance = "https://login.windows.net/{0}";
                    string ResourceId = "https://database.windows.net/";

                    AuthenticationContext authenticationContext = new(string.Format(AadInstance, aadTenantId));
                    ClientCredential clientCredential = new(clientId, clientSecretKey);

                    AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(ResourceId, clientCredential).Result;

                    var conn = (Microsoft.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();

                    conn.AccessToken = authenticationResult.AccessToken;

                }
                catch (System.Exception) { }
            }
        }

        public DbSet<Trip> Trip { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(configuration["Schema"]);

            //modelBuilder.Entity<LayerWater>()
            //            .Property(s => s.LastUpdate)
            //            .HasDefaultValueSql("GETDATE()")
            //            .ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<LayerWaterPrediction>()
            //            .Property(s => s.LastUpdate)
            //            .HasDefaultValueSql("GETDATE()")
            //            .ValueGeneratedOnAddOrUpdate();

            #region Seeds
            #endregion

        }
    }
}