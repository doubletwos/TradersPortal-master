namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilepathGone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "Trader_TraderId", "dbo.Traders");
            DropIndex("dbo.FilePaths", new[] { "Trader_TraderId" });
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        Trader_TraderId = c.Int(),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            CreateIndex("dbo.FilePaths", "Trader_TraderId");
            AddForeignKey("dbo.FilePaths", "Trader_TraderId", "dbo.Traders", "TraderId");
        }
    }
}
