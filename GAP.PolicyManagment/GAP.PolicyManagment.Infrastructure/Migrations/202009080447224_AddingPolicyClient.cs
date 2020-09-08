namespace GAP.PolicyManagment.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPolicyClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PolicyClients", "Policy_PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyClients", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.PolicyClients", new[] { "Policy_PolicyId" });
            DropIndex("dbo.PolicyClients", new[] { "Client_ClientId" });
            DropTable("dbo.PolicyClients");

            CreateTable(
                "dbo.PolicyClients",
                c => new
                    {
                        PolicyClientId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        PolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PolicyId);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PolicyClients",
                c => new
                    {
                        Policy_PolicyId = c.Int(nullable: false),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Policy_PolicyId, t.Client_ClientId });
            
            DropForeignKey("dbo.PolicyClients", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyClients", "ClientId", "dbo.Clients");
            DropIndex("dbo.PolicyClients", new[] { "PolicyId" });
            DropIndex("dbo.PolicyClients", new[] { "ClientId" });
            DropTable("dbo.PolicyClients");
            CreateIndex("dbo.PolicyClients", "Client_ClientId");
            CreateIndex("dbo.PolicyClients", "Policy_PolicyId");
            AddForeignKey("dbo.PolicyClients", "Client_ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
            AddForeignKey("dbo.PolicyClients", "Policy_PolicyId", "dbo.Policies", "PolicyId", cascadeDelete: true);
        }
    }
}
