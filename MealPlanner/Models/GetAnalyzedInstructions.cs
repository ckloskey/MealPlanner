using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GetAnalyzedInstructions
    {
        [Key]
        public string name { get; set; }
        public List<GetAnalyzedInstructionsStep> steps { get; set; }
        
    }
}