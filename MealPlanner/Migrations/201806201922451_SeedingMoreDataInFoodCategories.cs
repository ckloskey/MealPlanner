namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMoreDataInFoodCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES('Seafood')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES('Eggs')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES('Condiments')");
        }
        
        public override void Down()
        {
        }
    }
}
