namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeeding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodItems", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.Recipes", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.FoodItems", "GeneralUser_Id1", "dbo.GeneralUsers");
            DropIndex("dbo.FoodItems", new[] { "GeneralUser_Id" });
            DropIndex("dbo.FoodItems", new[] { "GeneralUser_Id1" });
            DropIndex("dbo.Recipes", new[] { "GeneralUser_Id" });
            AddColumn("dbo.FoodItems", "DateBought", c => c.DateTime(nullable: false));
            AddColumn("dbo.FoodItems", "ExpirationInDays", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralUsers", "FirstName", c => c.String());
            AddColumn("dbo.GeneralUsers", "LastName", c => c.String());
            DropColumn("dbo.FoodCategories", "Food");
            DropColumn("dbo.FoodCategories", "MinDurationInDays");
            DropColumn("dbo.FoodCategories", "MaxDurationinDays");
            DropColumn("dbo.FoodItems", "GeneralUser_Id");
            DropColumn("dbo.FoodItems", "GeneralUser_Id1");
            DropColumn("dbo.Recipes", "GeneralUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "GeneralUser_Id", c => c.Int());
            AddColumn("dbo.FoodItems", "GeneralUser_Id1", c => c.Int());
            AddColumn("dbo.FoodItems", "GeneralUser_Id", c => c.Int());
            AddColumn("dbo.FoodCategories", "MaxDurationinDays", c => c.Int(nullable: false));
            AddColumn("dbo.FoodCategories", "MinDurationInDays", c => c.Int(nullable: false));
            AddColumn("dbo.FoodCategories", "Food", c => c.String());
            DropColumn("dbo.GeneralUsers", "LastName");
            DropColumn("dbo.GeneralUsers", "FirstName");
            DropColumn("dbo.FoodItems", "ExpirationInDays");
            DropColumn("dbo.FoodItems", "DateBought");
            CreateIndex("dbo.Recipes", "GeneralUser_Id");
            CreateIndex("dbo.FoodItems", "GeneralUser_Id1");
            CreateIndex("dbo.FoodItems", "GeneralUser_Id");
            AddForeignKey("dbo.FoodItems", "GeneralUser_Id1", "dbo.GeneralUsers", "Id");
            AddForeignKey("dbo.Recipes", "GeneralUser_Id", "dbo.GeneralUsers", "Id");
            AddForeignKey("dbo.FoodItems", "GeneralUser_Id", "dbo.GeneralUsers", "Id");
        }
    }
}
