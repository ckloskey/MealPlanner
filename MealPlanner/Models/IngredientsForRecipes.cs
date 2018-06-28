using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class IngredientsForRecipes
    {
        [Key]
        public int ArbitraryId { get; set; }
        public Recipe IdForRecipe { get; set; }
        public int RecipeId { get; set; }
        [Display(Name ="Ingredient Name")]
        public string IngredientName { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }
}