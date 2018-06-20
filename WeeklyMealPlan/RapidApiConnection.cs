using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidAPISDK;
using WeeklyMealPlan.Ignored;

namespace WeeklyMealPlan
{
    public class RapidApiConnection
    {
        //API steps:
        //Get Random recipes to obtain Id(or Get Similar Recipes)
        //Use Id and Get Analyzed Recipe Instructions

        public static void ConnectionString()
        {
            //mashape (for unirest): JsDP2iHkAgmshwERFtVQk1t9uTlnp1bMLi4jsnW5wWkk97jreL
            //rapidApi: 9524b29f-cbd6-4847-bbd8-2c54a2ddb144

            RapidAPI RapidApi = new RapidAPI(APIKeys.projectName, APIKeys.rapidKey);
        }

        public void GetRandomRecipes()
        {
            //Task<HttpResponse<MyClass>> response = Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/random?number=1")
            //.header("X-Mashape-Key", "JPy2T3JUc1msh6GJ4u64n95J0isip1r3yu0jsn1ITqrbPu6YqD")
            //.header("X-Mashape-Host", "spoonacular-recipe-food-nutrition-v1.p.mashape.com")
            //.asJson();
        }

        //private static RapidAPI RapidApi = new RapidAPI(project: "ProjectName", key: "ProjectKey");
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