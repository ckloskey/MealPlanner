using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DietaryRestriction
    {
        public int Id { get; set; }
        public string Restriction { get; set; }
        public bool IsAllergic { get; set; }
    }
}