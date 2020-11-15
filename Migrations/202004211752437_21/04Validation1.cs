namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2104Validation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Traders", "Telephone", c => c.String(nullable: false));
            AlterColumn("dbo.Traders", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Traders", "Email", c => c.String());
            AlterColumn("dbo.Traders", "Telephone", c => c.String());
        }
    }
}
