using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeeklyMealPlan.Models
{
    public class User
    {
        public int Id { get; set; }
        public List<FridgeItem> InventoryList { get; set; }
        public List<ShoppingItem> ShoppingList { get; set; }
        public List<Recipe> SavedRecipes { get; set; }

    }
}