using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class DeserializeComplexCallWinePairing
    {
        public List<string> pairedWines { get; set; }
        public string pairingText { get; set; }
        public List<DeseriaizeComplexCallProductMatch> productMatches { get; set; }
    }
}