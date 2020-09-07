namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using GAP.PolicyManagment.Infrastructure.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.PolicyManagment.Infrastructure.PolicyManagmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PolicyManagmentContext context)
        {
            context.CoverageTypes.AddOrUpdate(
                new CoverageType() { Name = "Terremoto" },
                new CoverageType() { Name = "Incendio" },
                new CoverageType() { Name = "Robo" },
                new CoverageType() { Name = "Pérdida" }
                );

            context.RiskTypes.AddOrUpdate(
               new RiskType() { Name = "Bajo" },
               new RiskType() { Name = "Medio" },
               new RiskType() { Name = "Medio-Alto" },
               new RiskType() { Name = "Alto" }
               );
        }
    }
}
