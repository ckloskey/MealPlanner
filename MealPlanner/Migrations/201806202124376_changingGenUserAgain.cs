namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingGenUserAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "GeneralUserId", "dbo.GeneralUsers");
            DropIndex("dbo.Recipes", new[] { "GeneralUserId" });
            DropPrimaryKey("dbo.GeneralUsers");
            AddColumn("dbo.GeneralUsers", "RecipeId", c => c.Int(nullable: false));
            DropColumn("dbo.GeneralUsers", "Id");
            AddColumn("dbo.GeneralUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.GeneralUsers", "Id");
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropColumn("dbo.Recipes", "GeneralUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "GeneralUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            DropPrimaryKey("dbo.GeneralUsers");
            AlterColumn("dbo.GeneralUsers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.GeneralUsers", "RecipeId");
            AddPrimaryKey("dbo.GeneralUsers", "Id");
            CreateIndex("dbo.Recipes", "GeneralUserId");
            AddForeignKey("dbo.Recipes", "GeneralUserId", "dbo.GeneralUsers", "Id", cascadeDelete: true);
        }
    }
}
