namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMoreFoodCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('vegetable')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('fruit')");
        }
        
        public override void Down()
        {
        }
    }
}
