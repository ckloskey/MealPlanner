﻿using System;
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

        ApplicationDbContext _context;
        public RapidApiConnection()
        {
            _context = new ApplicationDbContext();
        }
		//API steps:
		//Get Random recipes to obtain Id(or Get Similar Recipes)
		//Use Id and Get Analyzed Recipe Instructions
        public static object GetApiRequest(string urlStringRoute)
        {
            string wholeUrlPath = "https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/" + urlStringRoute;
            Task<HttpResponse<string>> response = Unirest.get(wholeUrlPath)
            .header("X-Mashape-Key", APIKeys.mashapeKey)
            .header("Accept", "application/json")
            .asStringAsync();
            return response;
            
        }
        public Recipe SearchByIngredients()
        {
            var fridgeItems = _context.FoodItem.ToList();
            var ingredientsList = string.Join(",", fridgeItems.Select(o => o.Name));
            
            string urlString = "findByIngredients?ingredients=" + ingredientsList + "&number=1&ranking=2";
            //ingredients to be included
            //ranking == "1" <-- maximizes ingredients
            Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=" + ingredientsList + "&number=1&ranking=2")
           .header("X-Mashape-Key", APIKeys.mashapeKey)
           .header("Accept", "application/json")
           .asStringAsync();
            string result = response.Result.Body;

            SearchByIngredients[] rootObject = JsonConvert.DeserializeObject<SearchByIngredients[]>(result);
            var root = rootObject[0];
            Recipe newRecipe = new Recipe
            {
                apiId = root.id,
                title = root.title,
                image = root.image
            };


            _context.Recipe.Add(newRecipe);
            _context.SaveChanges();
            return newRecipe;
        }

        public void GetAnalyzedReceipeInstructions(Recipe recipe)
        {
            string urlString = "https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/" + recipe.apiId + "/analyzedInstructions?stepBreakdown=true";
            Task<HttpResponse<string>> response = Unirest.get(urlString)
           .header("X-Mashape-Key", APIKeys.mashapeKey)
           .header("Accept", "application/json")
           .asStringAsync();

            string result = response.Result.Body;

            GetAnalyzedInstructions[] rootObject = JsonConvert.DeserializeObject<GetAnalyzedInstructions[]>(result);
            var root = rootObject[0];
            GetAnalyzedInstructions instructions = new GetAnalyzedInstructions();
            instructions.name = recipe.title;
            instructions.steps = root.steps;
            _context.SaveChanges();

        }
        //may have to use for filtering out allergies. Counts as 3 api calls
        //"https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/searchComplex?addRecipeInformation=false&excludeIngredients=coconut%2C+mango&fillIngredients=false&includeIngredients=onions%2C+lettuce%2C+tomato&instructionsRequired=false&intolerances=nuts&limitLicense=false&number=1&offset=<required>&ranking=2&type=main+course"
    }
}