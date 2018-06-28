using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class StepsForRecipe
    {
        [Key]
        public int ArbitraryId { get; set; }
        public Recipe IdForRecipe { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }
    }
}