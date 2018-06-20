namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDietaryRestrictionTableAndFKinUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietaryRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Restriction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GeneralUsers", "RestrictionId", c => c.Int(nullable: false));
            CreateIndex("dbo.GeneralUsers", "RestrictionId");
            AddForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            DropColumn("dbo.GeneralUsers", "RestrictionId");
            DropTable("dbo.DietaryRestrictions");
        }
    }
}
