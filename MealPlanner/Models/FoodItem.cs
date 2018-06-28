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
        [DataType(DataType.Date)]
        public DateTime DatePurchased { get; set; }
        [Display(Name="Expiration (In number of Days)")]
        public int ExpirationInDays { get; set; }
        [Display(Name="Food Category")]
        public int FoodCategoryId { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }

    }
}