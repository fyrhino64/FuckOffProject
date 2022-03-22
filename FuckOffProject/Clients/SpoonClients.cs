﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckOffProject.Clients;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;

namespace FuckOffProject
{
    public class SpoonClients
    {
        string BasePath = "https://api.spoonacular.com";
        public RestClient RestClient { get; set; }
        string apiKey {get; set;}
        string endPoint { get; set; }


        public void GetAuthToken()
        {
            apiKey = AuthToken.GetAuthToken();
        }

        public RestClient SetUpRestClient(string BasePath)
        {
            RestClient client = new RestClient(BasePath);
            return client;
        }

        public RestRequest SetUpRestRequest(string endPoint, string ingredientName, string apiKey)
        {
            RestRequest request = new RestRequest(endPoint + ingredientName + "&apiKey=" + apiKey, Method.GET);
            request.AddHeader("Accept", "application/json;odata=verbose");
            return request;
        }

        public List<RecipeInfo> GetRecipesByIngredient(string ingredientName)
        {
            endPoint = "/recipes/findByIngredients?ingredients=";
            GetAuthToken();
            var client = SetUpRestClient(BasePath);
            var request = SetUpRestRequest(endPoint, ingredientName,  apiKey);
            IRestResponse response = client.Execute(request);
            var ingredientList = JsonConvert.DeserializeObject<List<RecipeInfo>>(response.Content);
            return ingredientList;
        }
    }

}

    