using FuckOffProject.Context;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject.Components
{
    public class SpoonComponent
    {
        private readonly RecipeContext _context;
        private readonly SpoonClients _client;
        public SpoonComponent(RecipeContext context, SpoonClients client)
        {
            _context = context;
            _client = client;
        }

        public List<RecipeInfo> GetRecipesByIngredient(string ingredientName, char callIndicator)
        {
            var endPoint = GetEndPoint(callIndicator);
            RestRequest request = _client.SetUpRestRequest(endPoint, ingredientName);
            var response = _client.Executes(request);
            _context.ReturnedRecipes = JsonConvert.DeserializeObject<List<RecipeInfo>>(response.Result.Content);
            return _context.ReturnedRecipes;
        }

        public string GetEndPoint(char callName)
        {
            switch (callName)
            {
                case 'R':
                    return "/recipes/findByIngredients?ingredients=";
                default:
                    return null;
            }
        }
    }
}
