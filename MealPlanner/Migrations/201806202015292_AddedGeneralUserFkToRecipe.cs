namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGeneralUserFkToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "GeneralUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "GeneralUserId");
            AddForeignKey("dbo.Recipes", "GeneralUserId", "dbo.GeneralUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "GeneralUserId", "dbo.GeneralUsers");
            DropIndex("dbo.Recipes", new[] { "GeneralUserId" });
            DropColumn("dbo.Recipes", "GeneralUserId");
        }
    }
}
