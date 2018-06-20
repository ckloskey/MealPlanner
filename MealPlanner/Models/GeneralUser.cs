using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GeneralUser
    {
        public int Id { get; set; }
        public List<FoodItem> InventoryList { get; set; }
        public List<FoodItem> ShoppingList { get; set; }
        public List<Recipe> SavedRecipes { get; set; }

    }
}