using MealPlanner.Models;
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
            ConfigureAuth(app);
        }
    }
}
