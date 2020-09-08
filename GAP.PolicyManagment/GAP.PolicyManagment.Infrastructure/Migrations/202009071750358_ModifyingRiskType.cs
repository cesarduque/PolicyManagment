namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingRiskType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policies", "RiskType_RiskTypeId", "dbo.RiskTypes");
            DropIndex("dbo.Policies", new[] { "RiskType_RiskTypeId" });
            RenameColumn(table: "dbo.Policies", name: "RiskType_RiskTypeId", newName: "RiskTypeId");
            AlterColumn("dbo.Policies", "RiskTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Policies", "RiskTypeId");
            AddForeignKey("dbo.Policies", "RiskTypeId", "dbo.RiskTypes", "RiskTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "RiskTypeId", "dbo.RiskTypes");
            DropIndex("dbo.Policies", new[] { "RiskTypeId" });
            AlterColumn("dbo.Policies", "RiskTypeId", c => c.Int());
            RenameColumn(table: "dbo.Policies", name: "RiskTypeId", newName: "RiskType_RiskTypeId");
            CreateIndex("dbo.Policies", "RiskType_RiskTypeId");
            AddForeignKey("dbo.Policies", "RiskType_RiskTypeId", "dbo.RiskTypes", "RiskTypeId");
        }
    }
}
