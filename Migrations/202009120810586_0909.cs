namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0909 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "StateId", "dbo.States");
            DropIndex("dbo.AspNetUsers", new[] { "StateId" });
            DropColumn("dbo.AspNetUsers", "BusinessName");
            DropColumn("dbo.AspNetUsers", "StateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "StateId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BusinessName", c => c.String());
            CreateIndex("dbo.AspNetUsers", "StateId");
            AddForeignKey("dbo.AspNetUsers", "StateId", "dbo.States", "StateId", cascadeDelete: true);
        }
    }
}
