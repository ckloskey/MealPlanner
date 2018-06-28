namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingForWeirdStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GetAnalyzedInstructionsSteps", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.GetAnalyzedInstructionsSteps", new[] { "Recipe_Id" });
            //DropColumn("dbo.StepsForRecipes", "RecipeId");
            //RenameColumn(table: "dbo.StepsForRecipes", name: "Recipe_Id", newName: "RecipeId");
            //AddForeignKey("dbo.StepsForRecipes", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropTable("dbo.GetAnalyzedInstructionsSteps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GetAnalyzedInstructionsSteps",
                c => new
                    {
                        number = c.Int(nullable: false, identity: true),
                        step = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.number);
            
            //DropForeignKey("dbo.StepsForRecipes", "RecipeId", "dbo.Recipes");
            //RenameColumn(table: "dbo.StepsForRecipes", name: "RecipeId", newName: "Recipe_Id");
            //AddColumn("dbo.StepsForRecipes", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.GetAnalyzedInstructionsSteps", "Recipe_Id");
            AddForeignKey("dbo.GetAnalyzedInstructionsSteps", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
