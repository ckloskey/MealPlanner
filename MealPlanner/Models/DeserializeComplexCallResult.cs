using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DeserializeComplexCallResult
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public bool cheap { get; set; }
        public bool veryPopular { get; set; }
        public bool sustainable { get; set; }
        public double weightWatcherSmartPoints { get; set; }
        public string gaps { get; set; }
        public bool lowFodmap { get; set; }
        public bool ketogenic { get; set; }
        public bool whole30 { get; set; }
        public double preparationMinutes { get; set; }
        public double cookingMinutes { get; set; }
        public string sourceUrl { get; set; }
        public string spoonacularSourceUrl { get; set; }
        public int aggregateLikes { get; set; }
        public double spoonacularScore { get; set; }
        public double healthScore { get; set; }
        public string creditText { get; set; }
        public string sourceName { get; set; }
        public double pricePerServing { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public double readyInMinutes { get; set; }
        public double servings { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public List<object> cuisines { get; set; }
        public List<string> dishTypes { get; set; }
        public List<string> diets { get; set; }
        public List<object> occasions { get; set; }
        public DeserializeComplexCallWinePairing winePairing { get; set; }
        public List<GetAnalyzedInstructions> analyzedInstructions { get; set; }
        public string creditsText { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public int likes { get; set; }
    }
}