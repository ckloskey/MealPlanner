namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name", "dbo.GetAnalyzedInstructions");
            DropIndex("dbo.GetAnalyzedInstructionsSteps", new[] { "GetAnalyzedInstructions_name" });
            CreateTable(
                "dbo.IngredientsForRecipes",
                c => new
                    {
                        ArbitraryId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        IngredientName = c.String(),
                        Amount = c.Double(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ArbitraryId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.StepsForRecipes",
                c => new
                    {
                        ArbitraryId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        StepNumber = c.Int(nullable: false),
                        StepDescription = c.String(),
                    })
                .PrimaryKey(t => t.ArbitraryId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            DropColumn("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name");
            DropTable("dbo.GetAnalyzedInstructions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GetAnalyzedInstructions",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.name);
            
            AddColumn("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name", c => c.String(maxLength: 128));
            DropForeignKey("dbo.StepsForRecipes", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.IngredientsForRecipes", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.StepsForRecipes", new[] { "RecipeId" });
            DropIndex("dbo.IngredientsForRecipes", new[] { "RecipeId" });
            DropTable("dbo.StepsForRecipes");
            DropTable("dbo.IngredientsForRecipes");
            CreateIndex("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name");
            AddForeignKey("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name", "dbo.GetAnalyzedInstructions", "name");
        }
    }
}
