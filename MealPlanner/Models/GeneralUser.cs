using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GeneralUser
    {

        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DietaryRestriction Restriction { get; set; }
        public int RestrictionId { get; set; }

    }
}