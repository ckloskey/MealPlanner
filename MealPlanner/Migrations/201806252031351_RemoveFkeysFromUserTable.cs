namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFkeysFromUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            DropColumn("dbo.GeneralUsers", "RestrictionId");
            DropColumn("dbo.GeneralUsers", "RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralUsers", "RecipeId", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int(nullable: false));
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
