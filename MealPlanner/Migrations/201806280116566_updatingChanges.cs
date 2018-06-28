namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "name_name", "dbo.GetAnalyzedInstructions");
            DropIndex("dbo.Recipes", new[] { "name_name" });
            DropColumn("dbo.Recipes", "name_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "name_name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recipes", "name_name");
            AddForeignKey("dbo.Recipes", "name_name", "dbo.GetAnalyzedInstructions", "name");
        }
    }
}
