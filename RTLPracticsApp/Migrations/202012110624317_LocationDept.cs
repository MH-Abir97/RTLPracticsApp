namespace RTLPracticsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Location");
        }
    }
}
