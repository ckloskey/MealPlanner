namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodCategories", "FoodItem_Id", c => c.Int());
            CreateIndex("dbo.FoodCategories", "FoodItem_Id");
            AddForeignKey("dbo.FoodCategories", "FoodItem_Id", "dbo.FoodItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodCategories", "FoodItem_Id", "dbo.FoodItems");
            DropIndex("dbo.FoodCategories", new[] { "FoodItem_Id" });
            DropColumn("dbo.FoodCategories", "FoodItem_Id");
        }
    }
}
