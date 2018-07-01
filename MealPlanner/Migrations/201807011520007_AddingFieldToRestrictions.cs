namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldToRestrictions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DietaryRestrictions", "IsAllergic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DietaryRestrictions", "IsAllergic");
        }
    }
}
