using GAP.PolicyManagment.Infrastructure.Models;
using System.Data.Entity;

namespace GAP.PolicyManagment.Infrastructure
{
    public class PolicyManagmentContext : DbContext
    {
        public PolicyManagmentContext() : base("name=PolicyManagmentConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PolicyManagmentContext, Migrations.Configuration>());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CoverageType> CoverageTypes { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<PolicyCoverageType> PolicyCoverageTypes { get; set; }
        public DbSet<PolicyClient> PolicyClients { get; set; }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
