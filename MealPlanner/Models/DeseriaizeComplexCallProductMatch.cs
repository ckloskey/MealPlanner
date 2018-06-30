using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DeseriaizeComplexCallProductMatch
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string imageUrl { get; set; }
        public double averageRating { get; set; }
        public int ratingCount { get; set; }
        public double score { get; set; }
        public string link { get; set; }
    }
}