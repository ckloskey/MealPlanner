namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedoingDatabase : DbMigration
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
            
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DatePurchased = c.DateTime(nullable: false),
                        ExpirationInDays = c.Int(nullable: false),
                        FoodCategory = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.GeneralUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RestrictionId = c.Int(nullable: true),
                        RecipeId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.DietaryRestrictions", t => t.RestrictionId, cascadeDelete: true)
                .Index(t => t.RestrictionId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GetAnalyzedInstructions",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.name);
            
            CreateTable(
                "dbo.GetAnalyzedInstructionsSteps",
                c => new
                    {
                        number = c.Int(nullable: false, identity: true),
                        step = c.String(),
                        GetAnalyzedInstructions_name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.number)
                .ForeignKey("dbo.GetAnalyzedInstructions", t => t.GetAnalyzedInstructions_name)
                .Index(t => t.GetAnalyzedInstructions_name);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            Sql("INSERT INTO dbo.AspNetRoles(Id, Name) VALUES (1, 'GeneralUser')");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SearchByIngredients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        image = c.String(),
                        imageType = c.String(),
                        usedIngredientCount = c.Int(nullable: false),
                        missedIngredientCount = c.Int(nullable: false),
                        likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ShoppingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.Food_Id)
                .Index(t => t.Food_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES('nut')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES('soy')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES('dairy')");
            Sql("INSERT INTO dbo.DietaryRestrictions(Restriction) VALUES('egg')");

        }
        

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingItems", "Food_Id", "dbo.FoodCategories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GetAnalyzedInstructionsSteps", "GetAnalyzedInstructions_name", "dbo.GetAnalyzedInstructions");
            DropForeignKey("dbo.GeneralUsers", "RestrictionId", "dbo.DietaryRestrictions");
            DropForeignKey("dbo.GeneralUsers", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.FoodItems", "Category_Id", "dbo.FoodCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ShoppingItems", new[] { "Food_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GetAnalyzedInstructionsSteps", new[] { "GetAnalyzedInstructions_name" });
            DropIndex("dbo.GeneralUsers", new[] { "RecipeId" });
            DropIndex("dbo.GeneralUsers", new[] { "RestrictionId" });
            DropIndex("dbo.FoodItems", new[] { "Category_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShoppingItems");
            DropTable("dbo.SearchByIngredients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.GetAnalyzedInstructionsSteps");
            DropTable("dbo.GetAnalyzedInstructions");
            DropTable("dbo.Recipes");
            DropTable("dbo.GeneralUsers");
            DropTable("dbo.FoodItems");
            DropTable("dbo.FoodCategories");
            DropTable("dbo.DietaryRestrictions");
        }
    }
}
