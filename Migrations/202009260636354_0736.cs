namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0736 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Traders", "IsTester", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Traders", "IsTester");
        }
    }
}
