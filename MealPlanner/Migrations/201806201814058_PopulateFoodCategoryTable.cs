namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFoodCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Meat')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Poultry')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Vegetable')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Fruit')");
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Dairy')");
        }
        
        public override void Down()
        {
        }
    }
}
