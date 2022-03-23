using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject
{
    public class IngredientDetails
    {
        [Newtonsoft.Json.JsonProperty("aisle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Aisle { get; set; }
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Amount { get; set; }
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Id { get; set; }
        [Newtonsoft.Json.JsonProperty("image", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Image { get; set; }
        [Newtonsoft.Json.JsonProperty("meta", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<string> Meta { get; set; }
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("original", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Original { get; set; }
        [Newtonsoft.Json.JsonProperty("originalName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginalName { get; set; }
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Unit { get; set; }
        [Newtonsoft.Json.JsonProperty("unitLong", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UnitLong { get; set; }
        [Newtonsoft.Json.JsonProperty("unitShort", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UnitShort { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static IngredientDetails FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IngredientDetails>(data);
        }
    }
}
