using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealPlanner.Ignored;
using RapidAPISDK;


namespace MealPlanner
{
	public class RapidApiConnection
	{
		//API steps:
		//Get Random recipes to obtain Id(or Get Similar Recipes)
		//Use Id and Get Analyzed Recipe Instructions
		private static RapidAPI RapidApi;

        public static void ConnectionString()
        {
            RapidApi = new RapidAPI(APIKeys.projectName, APIKeys.rapidKey);
		}

        //To call an API:
        public static void CallApi()
        {
            if (RapidApi == null)
            {
                ConnectionString();
            }
            List<Parameter> body = new List<Parameter>();

            body.Add(new DataParameter("ingredients", "chicken, tomatoe"));
            body.Add(new DataParameter("number", "1"));
            body.Add(new DataParameter("ranking", "2"));
            try
            {
                //https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients
                Dictionary<string, object> response = RapidApi.Call("spoonacular-recipe-food-nutrition", "findByIngredients", body.ToArray()).Result;
                object payload;

                if (response.TryGetValue("success", out payload))
                {

                }
                else
                {

                }
            }
            catch (RapidAPIServerException e)
            {
                Console.WriteLine(e.Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }

    }
}