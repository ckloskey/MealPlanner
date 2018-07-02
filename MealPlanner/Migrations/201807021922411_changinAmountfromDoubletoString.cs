namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changinAmountfromDoubletoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IngredientsForRecipes", "Amount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IngredientsForRecipes", "Amount", c => c.Double(nullable: false));
        }
    }
}
