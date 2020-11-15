namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2104Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "StateName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "StateName", c => c.String());
        }
    }
}
