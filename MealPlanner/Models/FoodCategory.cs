using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Food { get; set; }
        public int MinDurationInDays { get; set; }
        public int MaxDurationinDays { get; set; }
    }
}