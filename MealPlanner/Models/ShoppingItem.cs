using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public FoodCategory Food { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
    }
}