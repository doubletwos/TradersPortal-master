namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Traders", t => t.Trader_TraderId)
                .Index(t => t.Trader_TraderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "Trader_TraderId", "dbo.Traders");
            DropIndex("dbo.FilePaths", new[] { "Trader_TraderId" });
            DropTable("dbo.FilePaths");
        }
    }
}
