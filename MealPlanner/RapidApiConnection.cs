using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MealPlanner.Ignored;
using RapidAPISDK;
using unirest_net.http;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using MealPlanner.Models;
using System.Net.Http;
using System.Runtime.Serialization;
using System.IO;
using System.Text;


namespace MealPlanner
{
	public class RapidApiConnection
	{
		//API steps:
		//Get Random recipes to obtain Id(or Get Similar Recipes)
		//Use Id and Get Analyzed Recipe Instructions


        public static object GetApiRequest(string urlStringRoute)
        {
            string wholeUrlPath = "https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/" + urlStringRoute;
            Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=chicken%2C+pepper&number=&ranking=1")
            .header("X-Mashape-Key", APIKeys.mashapeKey)
            .header("Accept", "application/json")
            .asStringAsync();
            string result = response.Result.Body;
            return result;
        }
        public static object SearchByIngredients()
        {
            string urlString = "findByIngredients?ingredients";
            //ingredients to be included
            //ranking == "1" <-- maximizes ingredients
             Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=chicken%2C+pepper&number=&ranking=1")
            .header("X-Mashape-Key", APIKeys.mashapeKey)
            .header("Accept", "application/json")
            .asStringAsync();

            string result = response.Result.Body;

            SearchByIngredients[] rootObject = JsonConvert.DeserializeObject<SearchByIngredients[]>(result);
            return rootObject[0];
        }

        public static void GetAnalyzedReceipeInstructions(string recipeId)
        {
            //"https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/" + recipeId + "/analyzedInstructions?stepBreakdown=true"
            string urlString = recipeId + "/analyzedInstructions?stepBreakdown=true";

        }
        //may have to use for filtering out allergies. Counts as 3 api calls
        //"https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/searchComplex?addRecipeInformation=false&excludeIngredients=coconut%2C+mango&fillIngredients=false&includeIngredients=onions%2C+lettuce%2C+tomato&instructionsRequired=false&intolerances=nuts&limitLicense=false&number=1&offset=<required>&ranking=2&type=main+course"
    }
}