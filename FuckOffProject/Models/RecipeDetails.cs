using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject.Models
{
    public class RecipeDetails
    {
        public bool vegetarian { get; set;  }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryhealthy { get; set; }
        public bool veryPopular { get; set; }
        public bool sustainable { get; set; }
        public int? weightWatcherSmartPoints { get; set;}
        public string gaps { get; set; }
        public bool lowFodmap { get; set; }

        public int? aggregateLikes { get; set; }
        public double spoonacularScore { get; set; }
        public double healthScore { get; set; }
        public string creditsText { get; set; }
        public string license { get; set; }
        public string sourceName { get; set; }
        public double pricePerServing { get; set;}

        public ICollection<IngredientDetails> ExtendedIngredients { get; set; }
        public int? id { get; set; }

        public string title { get; set; }
        public int? readyInMinutes { get; set; }
        public int? servings { get; set; }
        public string sourceUrl { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public string summary { get; set; }
        public string cuisine { get; set; }
        public List<string> dishtypes { get; set; }
        public List<string> diets { get; set; }
        public List<string> occassions { get; set; }

        public List<string> winePairings { get; set; }
        public string instructions { get; set; }

        public List<AnalyzedInstructions> analyzedInstructions { get; set; }
        public int? originalId { get; set; }

        public string spoonacularSourceUrl { get; set; }

    }
}
