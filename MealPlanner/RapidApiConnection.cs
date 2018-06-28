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
using Newtonsoft.Json.Linq;

namespace MealPlanner
{
	public class RapidApiConnection
	{

        ApplicationDbContext _context;
        public RapidApiConnection()
        {
            _context = new ApplicationDbContext();
        }

        public static Task<HttpResponse<string>> GetApiRequest(string urlStringRoute)
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
            var response = GetApiRequest(urlString);
           // Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=" + ingredientsList + "&number=1&ranking=2")
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
            GetRecipeInfoCall(newRecipe);
            return newRecipe;
        }

        //public void GetAnalyzedReceipeInstructions(Recipe recipe)
        //{
        //    //string urlString = "https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/" + recipe.apiId + "/analyzedInstructions?stepBreakdown=true";
        //    string urlString = recipe.apiId.ToString() + "/analyzedInstructions?stepBreakdown=true";
        //    var response = GetApiRequest(urlString);
        //    string result = response.Result.Body;

        //    GetAnalyzedInstructions[] rootObject = JsonConvert.DeserializeObject<GetAnalyzedInstructions[]>(result);
        //    var root = rootObject[0];

        //    GetAnalyzedInstructions instructions = new GetAnalyzedInstructions
        //    {
        //        name = recipe.title,
        //        steps = root.steps

        //    };

        //    recipe.RecipeSteps = instructions.steps;
        //    List<string> gettingIngredients = new List<string>();
        //    foreach (var step in root.steps)
        //    {
        //        if ((step.ingredients != null) && (step.ingredients.Count != 0))
        //        {
        //            gettingIngredients.Add(step.ingredients.ToString());
        //        }
        //    }
        //    recipe.Ingredients = gettingIngredients;
        //    _context.SaveChanges();
        //}

        public void GetRandomRecipeMethods()
        {
            GetRecipeInfoCall(UpdateNewRecipe(GetRandomRecipe()));
        }
        public RandomRecipeObject GetRandomRecipe()
        {
            //Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/random?limitLicense=false&number=1")
            string urlString = "random?limitLicense=false&number=1";
            var response = GetApiRequest(urlString);
            string result = response.Result.Body;
            RandomRecipeObject rootObject = JsonConvert.DeserializeObject<RandomRecipeObject>(result);
            return rootObject;
        }
        
        //may have to use for filtering out allergies. Counts as 3 api calls
        //"https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/searchComplex?addRecipeInformation=false&excludeIngredients=coconut%2C+mango&fillIngredients=false&includeIngredients=onions%2C+lettuce%2C+tomato&instructionsRequired=false&intolerances=nuts&limitLicense=false&number=1&offset=<required>&ranking=2&type=main+course"

        public RandomRecipeObject GetSimilarRecipe(Recipe recipe)
        {
            //Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/156992/similar")
            string urlString = recipe.apiId.ToString() + "/similar";
            var response = GetApiRequest(urlString);
            string result = response.Result.Body;
            RandomRecipeObject rootObject = JsonConvert.DeserializeObject<RandomRecipeObject>(result);
            Recipe newRecipe = UpdateNewRecipe(rootObject);
            return rootObject;
        }

        public Recipe UpdateNewRecipe(RandomRecipeObject rootObject)
        {
            Recipe newRecipe = new Recipe
            {
                apiId = rootObject.recipes[0].id,
                title = rootObject.recipes[0].title,
                image = rootObject.recipes[0].image,
                Saved = false
            };

            _context.Recipe.Add(newRecipe);
            _context.SaveChanges();
            return newRecipe;
        }

        public void GetRecipeInfoCall(Recipe recipe)
        {
            string urlString = recipe.apiId.ToString() + "/information?includeNutrition=false";
            var response = GetApiRequest(urlString);
            var result = response.Result.Body;

            JObject jobject = JObject.Parse(result);
            var ingredientInfo = jobject.SelectToken("extendedIngredients");
            var stepInfo = jobject.SelectToken("analyzedInstructions");

            List<string> ingredientsRetreived = new List<string>();
            List<GetAnalyzedInstructionsStep> stepsRetreived = new List<GetAnalyzedInstructionsStep>();

            foreach (var ingredient in ingredientInfo)
            {
                IngredientsForRecipes ingredientsFor = new IngredientsForRecipes
                {
                    RecipeId = recipe.Id,
                    IngredientName = ingredient.SelectToken("name").ToString(),
                    Amount = (double)ingredient.SelectToken("amount"),
                    Unit = ingredient.SelectToken("unit").ToString()
                };
                _context.IngredientsForRecipes.Add(ingredientsFor);
            }

            GetAnalyzedInstructions[] rootObject = JsonConvert.DeserializeObject<GetAnalyzedInstructions[]>(stepInfo.ToString());
            var root = rootObject[0];

            foreach (var step in root.steps)
            {
                
                StepsForRecipe newStep = new StepsForRecipe
                {
                    RecipeId = recipe.Id,
                    StepNumber = step.number,
                    StepDescription = step.step
                };
                _context.StepsForRecipe.Add(newStep);
            }
            _context.SaveChanges();
        }
    }
}