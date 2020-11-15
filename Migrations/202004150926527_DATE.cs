namespace TradersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DATE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Traders", "RegistrationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Traders", "RegistrationDate", c => c.DateTime(nullable: false));
        }
    }
}
