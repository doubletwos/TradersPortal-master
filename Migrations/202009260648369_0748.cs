namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0748 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Traders", "IsTester");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Traders", "IsTester", c => c.Boolean());
        }
    }
}
