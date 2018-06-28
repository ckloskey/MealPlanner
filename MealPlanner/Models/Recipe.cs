using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int apiId { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public List<IngredientsForRecipes> Ingredients { get; set; }
        public List<StepsForRecipe> RecipeSteps { get; set; }
        public bool Saved { get; set; }
    }
}