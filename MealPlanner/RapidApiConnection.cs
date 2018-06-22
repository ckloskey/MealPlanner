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

        public static object SearchByIngredients()
        {
             Task<HttpResponse<string>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?ingredients=chicken%2C+pepper&number=&ranking=1")
            .header("X-Mashape-Key", APIKeys.mashapeKey)
            .header("Accept", "application/json")
            .asStringAsync();

            string result = response.Result.Body;

            RootObject[] rootObject = JsonConvert.DeserializeObject<RootObject[]>(result);
            return rootObject[0];
        }

    }
}