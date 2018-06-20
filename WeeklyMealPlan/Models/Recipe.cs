using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeeklyMealPlan.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> RecipeSteps { get; set; }
    }
}