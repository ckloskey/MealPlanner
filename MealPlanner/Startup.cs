﻿using MealPlanner.Models;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(MealPlanner.Startup))]
namespace MealPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            ApplicationDbContext db = new ApplicationDbContext();
            RapidApiConnection api = new RapidApiConnection();
            var recipe = db.Recipe.Where(p => p.Id == 11).ToList();
            api.TestGetRecipeInfoCall(recipe[0]);
            //api.GetRandomRecipeMethods();

        }
    }
}
