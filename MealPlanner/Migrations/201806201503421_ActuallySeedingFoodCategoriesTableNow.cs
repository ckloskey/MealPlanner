namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActuallySeedingFoodCategoriesTableNow : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Meat', 'beef', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Meat', 'lamb', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Meat', 'hamburger', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Meat', 'bacon', 4, 7)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Meat', 'steak', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Poultry', 'chicken', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Poultry', 'turkey', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Eggs', 'in shell', 21, 35)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Eggs', 'yolk', 2, 4)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Seafood', 'fish', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Seafood', 'shellfish', 1, 2)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Condiments', 'mustard', 240, 360)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Condiments', 'ketchup', 100, 180)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Condiments', 'salad dressing', 180, 270)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Condiments', 'mayonnaise', 60, 90)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Vegetable', 'lettuce', 4, 7)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Vegetable', 'broccoli', 7, 14)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Vegetable', 'carrot', 7, 14)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Vegetable', 'tomatoe', 7, 14)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Fruit', 'apple', 30, 60)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Fruit', 'banana', 2, 7)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Fruit', 'lemon', 30, 60)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Fruit', 'lime', 30, 60)");
            Sql("INSERT INTO dbo.FoodCategories (Category, Food, MinDurationInDays, MaxDurationInDays) VALUES('Fruit', 'Pineapple', 4, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
