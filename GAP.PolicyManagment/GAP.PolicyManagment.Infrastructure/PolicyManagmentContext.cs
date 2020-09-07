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
    }
}
