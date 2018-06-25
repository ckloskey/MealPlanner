namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeGeneralUserFKeysNUllable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            AlterColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int());
            AlterColumn("dbo.GeneralUsers", "RecipeId", c => c.Int());
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id");
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            AlterColumn("dbo.GeneralUsers", "RecipeId", c => c.Int(nullable: false));
            AlterColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int(nullable: false));
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
