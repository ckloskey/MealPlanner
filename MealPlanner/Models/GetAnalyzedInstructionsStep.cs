using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class GetAnalyzedInstructionsStep
    {
        [Key]
        public int number { get; set; }
        public string step { get; set; }
        public List<object> ingredients { get; set; }
        public List<object> equipment { get; set; }
    }
}