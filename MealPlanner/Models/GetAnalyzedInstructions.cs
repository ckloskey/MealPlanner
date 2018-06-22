using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GetAnalyzedInstructions
    {
        public string name { get; set; }
        public List<GetAnalyzedInstructionsStep> steps { get; set; }
    }
}