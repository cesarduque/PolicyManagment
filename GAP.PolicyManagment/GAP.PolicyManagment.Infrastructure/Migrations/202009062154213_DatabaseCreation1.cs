namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        CoverageTime = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        RiskType_RiskTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.RiskTypes", t => t.RiskType_RiskTypeId)
                .Index(t => t.RiskType_RiskTypeId);
            
            CreateTable(
                "dbo.RiskTypes",
                c => new
                    {
                        RiskTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RiskTypeId);
            
            CreateTable(
                "dbo.CoverageTypes",
                c => new
                    {
                        CoverageTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CoverageTypeId);
            
            CreateTable(
                "dbo.PolicyCoverageTypes",
                c => new
                    {
                        PolicyCoverageTypeId = c.Int(nullable: false, identity: true),
                        CoveragePercentage = c.Int(nullable: false),
                        CoverageType_CoverageTypeId = c.Int(),
                        Policy_PolicyId = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyCoverageTypeId)
                .ForeignKey("dbo.CoverageTypes", t => t.CoverageType_CoverageTypeId)
                .ForeignKey("dbo.Policies", t => t.Policy_PolicyId)
                .Index(t => t.CoverageType_CoverageTypeId)
                .Index(t => t.Policy_PolicyId);
            
            CreateTable(
                "dbo.PolicyClients",
                c => new
                    {
                        Policy_PolicyId = c.Int(nullable: false),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Policy_PolicyId, t.Client_ClientId })
                .ForeignKey("dbo.Policies", t => t.Policy_PolicyId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .Index(t => t.Policy_PolicyId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyCoverageTypes", "Policy_PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyCoverageTypes", "CoverageType_CoverageTypeId", "dbo.CoverageTypes");
            DropForeignKey("dbo.Policies", "RiskType_RiskTypeId", "dbo.RiskTypes");
            DropForeignKey("dbo.PolicyClients", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.PolicyClients", "Policy_PolicyId", "dbo.Policies");
            DropIndex("dbo.PolicyClients", new[] { "Client_ClientId" });
            DropIndex("dbo.PolicyClients", new[] { "Policy_PolicyId" });
            DropIndex("dbo.PolicyCoverageTypes", new[] { "Policy_PolicyId" });
            DropIndex("dbo.PolicyCoverageTypes", new[] { "CoverageType_CoverageTypeId" });
            DropIndex("dbo.Policies", new[] { "RiskType_RiskTypeId" });
            DropTable("dbo.PolicyClients");
            DropTable("dbo.PolicyCoverageTypes");
            DropTable("dbo.CoverageTypes");
            DropTable("dbo.RiskTypes");
            DropTable("dbo.Policies");
            DropTable("dbo.Clients");
        }
    }
}
