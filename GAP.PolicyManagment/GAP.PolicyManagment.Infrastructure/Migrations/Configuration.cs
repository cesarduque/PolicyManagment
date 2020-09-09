namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using GAP.PolicyManagment.Infrastructure.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.PolicyManagment.Infrastructure.PolicyManagmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PolicyManagmentContext context)
        {
            context.Clients.AddOrUpdate(x => x.Name,
               new Client() { Name = "Tim" },
               new Client() { Name = "Stive" },
               new Client() { Name = "Bob" },
               new Client() { Name = "Avi" }
               );

            context.CoverageTypes.AddOrUpdate( x => x.Name,                
                new Models.CoverageType() { Name = "Terremoto" },
                new Models.CoverageType() { Name = "Incendio" },
                new Models.CoverageType() { Name = "Robo" },
                new Models.CoverageType() { Name = "Pérdida" }
                );

            context.RiskTypes.AddOrUpdate(x => x.Name,
               new RiskType() { Name = "Bajo" },
               new RiskType() { Name = "Medio" },
               new RiskType() { Name = "Medio-Alto" },
               new RiskType() { Name = "Alto" }
               );
        }
    }
}
