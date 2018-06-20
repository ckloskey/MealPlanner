using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePurchased { get; set; }
        public int ExpirationInDays { get; set; }
        public FoodCategory Category { get; set; }
        public int FoodCategory { get; set; }
        
    }
}