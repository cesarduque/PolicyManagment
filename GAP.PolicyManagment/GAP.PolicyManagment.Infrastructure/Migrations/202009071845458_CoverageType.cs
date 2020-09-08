namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoverageType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PolicyCoverageTypes", "CoverageType_CoverageTypeId", "dbo.CoverageTypes");
            DropForeignKey("dbo.PolicyCoverageTypes", "Policy_PolicyId", "dbo.Policies");
            DropIndex("dbo.PolicyCoverageTypes", new[] { "CoverageType_CoverageTypeId" });
            DropIndex("dbo.PolicyCoverageTypes", new[] { "Policy_PolicyId" });
            RenameColumn(table: "dbo.PolicyCoverageTypes", name: "CoverageType_CoverageTypeId", newName: "CoverageTypeId");
            RenameColumn(table: "dbo.PolicyCoverageTypes", name: "Policy_PolicyId", newName: "PolicyId");
            AlterColumn("dbo.PolicyCoverageTypes", "CoverageTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.PolicyCoverageTypes", "PolicyId", c => c.Int(nullable: false));
            CreateIndex("dbo.PolicyCoverageTypes", "PolicyId");
            CreateIndex("dbo.PolicyCoverageTypes", "CoverageTypeId");
            AddForeignKey("dbo.PolicyCoverageTypes", "CoverageTypeId", "dbo.CoverageTypes", "CoverageTypeId", cascadeDelete: true);
            AddForeignKey("dbo.PolicyCoverageTypes", "PolicyId", "dbo.Policies", "PolicyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyCoverageTypes", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyCoverageTypes", "CoverageTypeId", "dbo.CoverageTypes");
            DropIndex("dbo.PolicyCoverageTypes", new[] { "CoverageTypeId" });
            DropIndex("dbo.PolicyCoverageTypes", new[] { "PolicyId" });
            AlterColumn("dbo.PolicyCoverageTypes", "PolicyId", c => c.Int());
            AlterColumn("dbo.PolicyCoverageTypes", "CoverageTypeId", c => c.Int());
            RenameColumn(table: "dbo.PolicyCoverageTypes", name: "PolicyId", newName: "Policy_PolicyId");
            RenameColumn(table: "dbo.PolicyCoverageTypes", name: "CoverageTypeId", newName: "CoverageType_CoverageTypeId");
            CreateIndex("dbo.PolicyCoverageTypes", "Policy_PolicyId");
            CreateIndex("dbo.PolicyCoverageTypes", "CoverageType_CoverageTypeId");
            AddForeignKey("dbo.PolicyCoverageTypes", "Policy_PolicyId", "dbo.Policies", "PolicyId");
            AddForeignKey("dbo.PolicyCoverageTypes", "CoverageType_CoverageTypeId", "dbo.CoverageTypes", "CoverageTypeId");
        }
    }
}
