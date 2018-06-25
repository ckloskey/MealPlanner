namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            AlterColumn("dbo.GeneralUsers", "FirstName", c => c.String());
            AlterColumn("dbo.GeneralUsers", "LastName", c => c.String());
            AlterColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int(nullable: true));
            AlterColumn("dbo.GeneralUsers", "RecipeId", c => c.Int(nullable: true));
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            AlterColumn("dbo.GeneralUsers", "RecipeId", c => c.Int());
            AlterColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int());
            AlterColumn("dbo.GeneralUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.GeneralUsers", "FirstName", c => c.String(nullable: false));
            CreateIndex("dbo.GeneralUsers", "RecipeId");
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id");
            AddForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes", "Id");
        }
    }
}
