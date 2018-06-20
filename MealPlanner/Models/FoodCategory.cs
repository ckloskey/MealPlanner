using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class FoodCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
    }
}