using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject.Context
{
    public class RecipeContext
    {
        public string Ingredient { get; set; }

        public IngredientDetails IngredientDetails { get; set; }
        public RecipeInfo RecipeInfo { get; set; }
        public List<RecipeInfo> ReturnedRecipes { get; set; }
    }
}
