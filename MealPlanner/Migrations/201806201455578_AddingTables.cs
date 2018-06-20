namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Food = c.String(),
                        MinDurationInDays = c.Int(nullable: false),
                        MaxDurationinDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodCategory = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        GeneralUser_Id = c.Int(),
                        GeneralUser_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.Category_Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id1)
                .Index(t => t.Category_Id)
                .Index(t => t.GeneralUser_Id)
                .Index(t => t.GeneralUser_Id1);
            
            CreateTable(
                "dbo.GeneralUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeneralUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id)
                .Index(t => t.GeneralUser_Id);
            
            CreateTable(
                "dbo.ShoppingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.Food_Id)
                .Index(t => t.Food_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingItems", "Food_Id", "dbo.FoodCategories");
            DropForeignKey("dbo.FoodItems", "GeneralUser_Id1", "dbo.GeneralUsers");
            DropForeignKey("dbo.Recipes", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.FoodItems", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.FoodItems", "Category_Id", "dbo.FoodCategories");
            DropIndex("dbo.ShoppingItems", new[] { "Food_Id" });
            DropIndex("dbo.Recipes", new[] { "GeneralUser_Id" });
            DropIndex("dbo.FoodItems", new[] { "GeneralUser_Id1" });
            DropIndex("dbo.FoodItems", new[] { "GeneralUser_Id" });
            DropIndex("dbo.FoodItems", new[] { "Category_Id" });
            DropTable("dbo.ShoppingItems");
            DropTable("dbo.Recipes");
            DropTable("dbo.GeneralUsers");
            DropTable("dbo.FoodItems");
            DropTable("dbo.FoodCategories");
        }
    }
}
