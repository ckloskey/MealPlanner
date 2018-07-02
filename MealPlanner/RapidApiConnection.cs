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
        public void SearchByIngredients()
        {
            var fridgeItems = _context.FoodItem.ToList();
            var ingredientsList = string.Join(",", fridgeItems.Select(o => o.Name));
            
            string urlString = "findByIngredients?ingredients=" + ingredientsList + "&number=4&ranking=1";
            //ingredients to be included
            //ranking == "1" <-- maximizes ingredients
            var response = GetApiRequest(urlString);
           // Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=" + ingredientsList + "&number=1&ranking=2")
            string result = response.Result.Body;

            SearchByIngredients[] rootObject = JsonConvert.DeserializeObject<SearchByIngredients[]>(result);
            //var root = rootObject[0];
            try
            {
                foreach (var recipe in rootObject)
                {
                    Recipe newRecipe = new Recipe
                    {
                        apiId = recipe.id,
                        title = recipe.title,
                        image = recipe.image
                    };
                    _context.Recipe.Add(newRecipe);
                    _context.SaveChanges();
                    GetRecipeInfoCall(newRecipe);
                }
            }
            catch (IndexOutOfRangeException)
            {
                _context.SaveChanges();
            }
        }

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

        public SimilarRecipeDeserializer GetSimilarRecipe(Recipe recipe)
        {
            //Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/156992/similar")
            string urlString = recipe.apiId.ToString() + "/similar";
            var response = GetApiRequest(urlString);
            string result = response.Result.Body;
            SimilarRecipeDeserializer[] rootObject = JsonConvert.DeserializeObject<SimilarRecipeDeserializer[]>(result);
            return rootObject[0];
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
            try
            {
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

            }
            catch (IndexOutOfRangeException)
            {
                Recipe ignoringRecipe = _context.Recipe.Find(recipe.Id);
                _context.Recipe.Remove(ignoringRecipe);
            }
            _context.SaveChanges();
        }

        public void GetComplexRecipeCall(int numberOfRecipes)
        {
            var fridgeItems = _context.FoodItem.ToList();
            var listOfIncludedIngredients = string.Join(",", fridgeItems.Select(o => o.Name));
            var intolerances = _context.DietaryRestriction.Where(o => o.IsAllergic == true).ToList();
            var listOfIntolerances = string.Join(",", intolerances.Select(o => o.Restriction));
            var listOfExcludedIngredients = listOfIntolerances;

            string urlString = "searchComplex?addRecipeInformation=true&excludeIngredients=" + listOfExcludedIngredients + 
                "&fillIngredients=false&includeIngredients=" + listOfIncludedIngredients + "&instructionsRequired=true&intolerances="
                + listOfIntolerances + "&limitLicense=false&number=1&offset=1&type=main+course";
            var response = GetApiRequest(urlString);
            string result = response.Result.Body;
            JObject jobject = JObject.Parse(result);
            if (numberOfRecipes == 1)
            {
                DeserializeComplexCall rootObject = JsonConvert.DeserializeObject<DeserializeComplexCall>(result);
                Recipe newRecipe = new Recipe
                {
                    apiId = rootObject.results[0].id,
                    title = rootObject.results[0].title,
                    image = rootObject.results[0].image,
                    Saved = false
                };
                _context.Recipe.Add(newRecipe);

                var stepInfo = jobject.SelectToken("results")[0].SelectToken("analyzedInstructions");
                GetAnalyzedInstructions[] rootSteps = JsonConvert.DeserializeObject<GetAnalyzedInstructions[]>(stepInfo.ToString());
                var root = rootSteps[0];
                    try
                    {
                        foreach (var step in root.steps)
                        {
                            StepsForRecipe newStep = new StepsForRecipe
                            {
                                RecipeId = newRecipe.Id,
                                StepNumber = step.number,
                                StepDescription = step.step
                            };
                            _context.StepsForRecipe.Add(newStep);
                        }
                    //if (root.steps[0].ingredients.Count != 0 && root.steps[0].ingredients != null)
                    //{
                    //    foreach (var ingredient in root.steps)
                    //    {
                    //        IngredientsForRecipes ingredientsFor = new IngredientsForRecipes
                    //        {
                    //            RecipeId = recipe.Id,
                    //            IngredientName = ingredient.SelectToken("name").ToString(),
                    //            Amount = (double)ingredient.SelectToken("amount"),
                    //            Unit = ingredient.SelectToken("unit").ToString()
                    //        };
                    //    }
                    //}
                }
                    catch (IndexOutOfRangeException)
                    {
                        Recipe ignoringRecipe = _context.Recipe.Find(newRecipe.Id);
                        _context.Recipe.Remove(ignoringRecipe);
                    }

            }
            else
            {
                DeserializeComplexCall[] rootObject = JsonConvert.DeserializeObject<DeserializeComplexCall[]>(result);
                foreach (var recipeResult in rootObject)
                {
                    Recipe recipe = new Recipe
                    {

                    };
                }
            }
        }
    }
}