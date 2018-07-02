namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changinbacktodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IngredientsForRecipes", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IngredientsForRecipes", "Amount", c => c.String());
        }
    }
}
