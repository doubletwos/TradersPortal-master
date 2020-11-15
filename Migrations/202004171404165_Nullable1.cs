namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Trader_TraderId", "dbo.Traders");
            DropIndex("dbo.Files", new[] { "Trader_TraderId" });
            RenameColumn(table: "dbo.Files", name: "Trader_TraderId", newName: "TraderId");
            AlterColumn("dbo.Files", "TraderId", c => c.Int(nullable: true));
            CreateIndex("dbo.Files", "TraderId");
            AddForeignKey("dbo.Files", "TraderId", "dbo.Traders", "TraderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "TraderId", "dbo.Traders");
            DropIndex("dbo.Files", new[] { "TraderId" });
            AlterColumn("dbo.Files", "TraderId", c => c.Int());
            RenameColumn(table: "dbo.Files", name: "TraderId", newName: "Trader_TraderId");
            CreateIndex("dbo.Files", "Trader_TraderId");
            AddForeignKey("dbo.Files", "Trader_TraderId", "dbo.Traders", "TraderId");
        }
    }
}
