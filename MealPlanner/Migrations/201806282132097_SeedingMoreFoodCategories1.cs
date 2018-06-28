namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMoreFoodCategories1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('grains')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('nuts')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('condiments')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('spices/herbs/oils')");
        }
        
        public override void Down()
        {
        }
    }
}
