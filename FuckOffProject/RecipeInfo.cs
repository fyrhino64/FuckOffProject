using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject
{
    public class RecipeInfo
    {
        [Newtonsoft.Json.JsonProperty ("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Id { get; set; }
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
        [Newtonsoft.Json.JsonProperty("image", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Image { get; set; }
        [Newtonsoft.Json.JsonProperty("imageType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImageType { get; set; }
        [Newtonsoft.Json.JsonProperty("usedIngredientCount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UsedIngredientCount { get; set; }
        [Newtonsoft.Json.JsonProperty("missedIngredientCount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MissedIngredientCount { get; set; }
        [Newtonsoft.Json.JsonProperty("missedIngredients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<IngredientDetails> MissedIngredients  { get; set;}
        [Newtonsoft.Json.JsonProperty("usedIngredients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<IngredientDetails> UsedIngredients { get; set; }
        [Newtonsoft.Json.JsonProperty("unUsedIngredients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<IngredientDetails> UnusedIngredients { get; set; }
        [Newtonsoft.Json.JsonProperty("likes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Likes { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static RecipeInfo FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RecipeInfo>(data);
        }

    }
}
