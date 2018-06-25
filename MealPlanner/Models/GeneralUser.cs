using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GeneralUser
    {
        
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<DietaryRestriction> Restrictions { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }


    }
}