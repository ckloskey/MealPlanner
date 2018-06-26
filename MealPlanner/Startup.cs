using MealPlanner.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealPlanner.Startup))]
namespace MealPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             ConfigureAuth(app);
            //RapidApiConnection api = new RapidApiConnection();
            //var testRandom = api.GetRandomRecipe();
            
        }
    }
}
