namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Traders", "StateId", "dbo.States");
            DropForeignKey("dbo.Traders", "TradeId", "dbo.Trades");
            DropIndex("dbo.Traders", new[] { "TradeId" });
            DropIndex("dbo.Traders", new[] { "StateId" });
            DropTable("dbo.States");
            DropTable("dbo.Traders");
            DropTable("dbo.Trades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        TradeId = c.Int(nullable: false, identity: true),
                        TradeName = c.String(),
                    })
                .PrimaryKey(t => t.TradeId);
            
            CreateTable(
                "dbo.Traders",
                c => new
                    {
                        TraderId = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false),
                        ContactFirstName = c.String(nullable: false),
                        ContactLastName = c.String(nullable: false),
                        Telephone = c.String(),
                        Mobile = c.String(nullable: false),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        TradeId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TraderId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateIndex("dbo.Traders", "StateId");
            CreateIndex("dbo.Traders", "TradeId");
            AddForeignKey("dbo.Traders", "TradeId", "dbo.Trades", "TradeId", cascadeDelete: true);
            AddForeignKey("dbo.Traders", "StateId", "dbo.States", "StateId", cascadeDelete: true);
        }
    }
}
