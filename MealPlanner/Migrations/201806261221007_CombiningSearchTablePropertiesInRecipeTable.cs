namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CombiningSearchTablePropertiesInRecipeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "apiId", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "title", c => c.String());
            AddColumn("dbo.Recipes", "image", c => c.String());
            DropColumn("dbo.Recipes", "Name");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Name", c => c.String());
            DropColumn("dbo.Recipes", "image");
            DropColumn("dbo.Recipes", "title");
            DropColumn("dbo.Recipes", "apiId");

        }
    }
}
