using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class GetAnalyzedInstructionsStep
    {
        public int number { get; set; }
        public string step { get; set; }
        public List<object> ingredients { get; set; }
        public List<object> equipment { get; set; }
    }
}