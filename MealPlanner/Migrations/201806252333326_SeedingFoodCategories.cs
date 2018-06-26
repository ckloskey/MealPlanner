namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingFoodCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('meat')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('poultry')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('dairy')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('egg')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('fish')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('greens')");

        }
        
        public override void Down()
        {
        }
    }
}
