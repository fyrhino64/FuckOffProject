using FuckOffProject.Context;
using FuckOffProject.Models;
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
            var endPoint = GetEndPoint(callIndicator, ingredientName);
            RestRequest request = _client.SetUpRestRequest(endPoint);
            var response = _client.Executes(request);
            _context.ReturnedRecipes = JsonConvert.DeserializeObject<List<RecipeInfo>>(response.Result.Content);
            return _context.ReturnedRecipes;
        }

        public RecipeDetails GetRecipeDetailsById(long recipeId, char callIndicator)
        {
            _context.recipeId = recipeId;
            var idToString = recipeId.ToString();
            var endPoint = GetEndPoint(callIndicator, idToString);
            RestRequest request = _client.SetUpRestRequest(endPoint);
            var response = _client.Executes(request);
            var recipeInfo = JsonConvert.DeserializeObject<RecipeDetails>(response.Result.Content);
            return recipeInfo;
        }

        public string GetEndPoint(char callName, string id)
        {
            switch (callName)
            {
                case 'R':
                    return $"/recipes/findByIngredients?ingredients={id}&";
                case 'I':
                    return $"/recipes/{id}/information?";
                default:
                    return null;
            }
        }
    }
}
