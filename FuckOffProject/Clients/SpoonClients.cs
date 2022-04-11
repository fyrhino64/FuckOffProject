using RestSharp;
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
    public class SpoonClients : IClientInterface
    {
        string BasePath = "https://api.spoonacular.com";
        public RestClient RestClient { get; set; }
        string apiKey {get; set;}
        string endPoint { get; set; }


        public void GetAuthToken()
        {
            apiKey = AuthToken.GetAuthToken();
        }

        public RestClient SetUpRestClient()
        {
            RestClient client = new RestClient(BasePath);
            return client;
        }

        public RestRequest SetUpRestRequest(string endPoint)
        {
            GetAuthToken();
            RestRequest request = new RestRequest(endPoint + "apiKey=" + apiKey, Method.GET);
            request.AddHeader("Accept", "application/json;odata=verbose");
            return request;
        }

        public async Task<IRestResponse> Executes(RestRequest args)
        {
            var client = SetUpRestClient();
            var response = client.Execute(args);
            return response;
        }
    }

}

    