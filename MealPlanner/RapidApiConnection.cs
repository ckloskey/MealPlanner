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

        public static void ConnectionString()
        {
            RapidAPI RapidApi = new RapidAPI(APIKeys.projectName, APIKeys.rapidKey);
        }

        public void GetRandomRecipes()
        {
            //Task<HttpResponse<MyClass>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/random?number=1")
            //.header("X-Mashape-Key", APIKeys.mashapeKey)
            //.header("X-Mashape-Host", "spoonacular-recipe-food-nutrition-v1.p.mashape.com")
            //.asJson();
        }

        private static RapidAPI RapidApi = new RapidAPI(APIKeys.projectName, key: APIKeys.rapidKey);
        //To call an API:
        public static void CallApi()
        {
            List<Parameter> body = new List<Parameter>();

            body.Add(new DataParameter("ParameterKey1", "ParameterValue1"));
            body.Add(new DataParameter("ParameterKey2", "ParameterValue2"));
            try
            {
                Dictionary<string, object> response = RapidApi.Call("APIName", "FunctionName").Result;
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

            }
            catch (Exception e)
            {

            }
        }
    }
}