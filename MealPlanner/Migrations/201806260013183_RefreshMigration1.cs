namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodItems", "Category_Id", "dbo.FoodCategories");
            DropIndex("dbo.FoodItems", new[] { "Category_Id" });
            AddColumn("dbo.FoodItems", "FoodCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.FoodItems", "FoodCategory");
            DropColumn("dbo.FoodItems", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "Category_Id", c => c.Int());
            AddColumn("dbo.FoodItems", "FoodCategory", c => c.Int(nullable: false));
            DropColumn("dbo.FoodItems", "FoodCategoryId");
            CreateIndex("dbo.FoodItems", "Category_Id");
            AddForeignKey("dbo.FoodItems", "Category_Id", "dbo.FoodCategories", "Id");
        }
    }
}
