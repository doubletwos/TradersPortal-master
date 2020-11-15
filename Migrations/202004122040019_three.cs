namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
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
                .PrimaryKey(t => t.TraderId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Trades", t => t.TradeId, cascadeDelete: false)
                .Index(t => t.TradeId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        TradeId = c.Int(nullable: false, identity: true),
                        TradeName = c.String(),
                    })
                .PrimaryKey(t => t.TradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Traders", "TradeId", "dbo.Trades");
            DropForeignKey("dbo.Traders", "StateId", "dbo.States");
            DropIndex("dbo.Traders", new[] { "StateId" });
            DropIndex("dbo.Traders", new[] { "TradeId" });
            DropTable("dbo.Trades");
            DropTable("dbo.Traders");
            DropTable("dbo.States");
        }
    }
}
