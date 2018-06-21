﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Recipe
    {
        //for random
        //root - body then GET extendedIngredients and get 'name' and 'amount' and 'unit' - recipes - 'analyzedInstructions' - GET 'steps'
        //for search by ingredients
        //comma seperated list of ingredients
        //number == 1 for max number of ingredients returned
        //ranking == 2, for minimize missing ingredients
        //return root, body, GET id
        //use id for Get Recipe Information parameter
        //follow random recipe method

        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> RecipeSteps { get; set; }
    }
}