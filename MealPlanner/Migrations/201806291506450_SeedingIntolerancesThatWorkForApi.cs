namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingIntolerancesThatWorkForApi : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('gluten')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('peanut')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('sesame')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('seafood')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('shellfish')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('tree nut')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES ('wheat')");
        }
        
        public override void Down()
        {
        }
    }
}
