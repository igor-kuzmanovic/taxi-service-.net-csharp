namespace TaxiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBasicValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Username", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Gender", c => c.Int());
            AlterColumn("dbo.Customers", "Role", c => c.Int());
            AlterColumn("dbo.Dispatchers", "Username", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Dispatchers", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Dispatchers", "Gender", c => c.Int());
            AlterColumn("dbo.Dispatchers", "Role", c => c.Int());
            AlterColumn("dbo.Drivers", "Username", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Drivers", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Drivers", "Gender", c => c.Int());
            AlterColumn("dbo.Drivers", "Role", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "Password", c => c.String());
            AlterColumn("dbo.Drivers", "Username", c => c.String());
            AlterColumn("dbo.Dispatchers", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Dispatchers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Dispatchers", "Password", c => c.String());
            AlterColumn("dbo.Dispatchers", "Username", c => c.String());
            AlterColumn("dbo.Customers", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Username", c => c.String());
        }
    }
}
