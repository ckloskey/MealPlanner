using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DeserializeComplexCallAnalyzedinstructions
    {
        public class AnalyzedInstruction
        {
            public string name { get; set; }
            public List<DeserializeComplexCallinstructionStep> steps { get; set; }
        }
    }
}