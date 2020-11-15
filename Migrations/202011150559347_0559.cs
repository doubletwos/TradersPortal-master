namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0559 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trades", "TradeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trades", "TradeName", c => c.String());
        }
    }
}
