using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DeserializeComplexCallinstructionStep
    {
        public int number { get; set; }
        public string step { get; set; }
        public List<object> ingredients { get; set; }
        public List<object> equipment { get; set; }
        public DeserializeComplexCallLength length { get; set; }
    }
}