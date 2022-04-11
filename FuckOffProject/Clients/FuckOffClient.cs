using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FuckOffProject.Clients
{
    public class FuckOffClient : IClientInterface
    {
        string BasePath = "https://foaas.com/";
        public RestClient RestClient { get; set; }

        public RestClient ReturnClient()
        {
            RestClient client = new RestClient(BasePath);
            return client;
        }

        public RestRequest SetUpRestRequest(string endPoint)
        {
            RestRequest restRequest = new RestRequest(endPoint, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public async Task<IRestResponse> Executes (RestRequest request)
        {
            var client = ReturnClient();
            var response = client.Execute(request);
            return response;
        }

    }
}
