namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GeneralUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.GeneralUsers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GeneralUsers", "LastName", c => c.String());
            AlterColumn("dbo.GeneralUsers", "FirstName", c => c.String());
        }
    }
}
