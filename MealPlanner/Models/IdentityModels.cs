﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MealPlanner.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<GeneralUser> GeneralUser { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<ShoppingItem> ShoppingItem { get; set; }
        public DbSet<DietaryRestriction> DietaryRestriction { get; set; }
        public DbSet<SearchByIngredients> SearchByIngredients { get; set; }
        public DbSet<IngredientsForRecipes> IngredientsForRecipes { get; set; }
        public DbSet<StepsForRecipe> StepsForRecipe { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}