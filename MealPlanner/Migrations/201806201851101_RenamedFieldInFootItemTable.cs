namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedFieldInFootItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodItems", "DatePurchased", c => c.DateTime(nullable: false));
            DropColumn("dbo.FoodItems", "DateBought");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "DateBought", c => c.DateTime(nullable: false));
            DropColumn("dbo.FoodItems", "DatePurchased");
        }
    }
}
