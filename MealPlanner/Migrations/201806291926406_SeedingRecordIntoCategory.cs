namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingRecordIntoCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.FoodCategories(Category) VALUES ('Misc')");
        }
        
        public override void Down()
        {
        }
    }
}
