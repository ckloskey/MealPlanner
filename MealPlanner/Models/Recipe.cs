using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Recipe
    {
        //for random
        //root - body - recipes - analyzedInstructions - steps - ingredients
        //for search by ingredients
        //comma seperated list of ingredients
        //number == 1 for max number of ingredients returned
        //ranking == 2, for minimize missing ingredients
        //return root, body, id
        //use id for Get Analyzed Recipe Instructions parameter
        //root - body - O - steps
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> RecipeSteps { get; set; }
    }
}