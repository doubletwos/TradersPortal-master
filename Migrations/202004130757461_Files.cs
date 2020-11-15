namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        TraderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Traders", t => t.TraderId, cascadeDelete: true)
                .Index(t => t.TraderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "TraderId", "dbo.Traders");
            DropIndex("dbo.Files", new[] { "TraderId" });
            DropTable("dbo.Files");
        }
    }
}
