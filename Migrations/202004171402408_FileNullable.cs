namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "TraderId", "dbo.Traders");
            DropIndex("dbo.Files", new[] { "TraderId" });
            RenameColumn(table: "dbo.Files", name: "TraderId", newName: "Trader_TraderId");
            AlterColumn("dbo.Files", "Trader_TraderId", c => c.Int());
            CreateIndex("dbo.Files", "Trader_TraderId");
            AddForeignKey("dbo.Files", "Trader_TraderId", "dbo.Traders", "TraderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Trader_TraderId", "dbo.Traders");
            DropIndex("dbo.Files", new[] { "Trader_TraderId" });
            AlterColumn("dbo.Files", "Trader_TraderId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Files", name: "Trader_TraderId", newName: "TraderId");
            CreateIndex("dbo.Files", "TraderId");
            AddForeignKey("dbo.Files", "TraderId", "dbo.Traders", "TraderId", cascadeDelete: true);
        }
    }
}
