namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSavedFieldToRecipes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Saved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Saved");
        }
    }
}
