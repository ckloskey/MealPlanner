using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class RandomRecipeObject
    {
        [JsonProperty("recipes")]
        public List<RandomRecipeRootProperties> recipes { get; set; }
    }
}