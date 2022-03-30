using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FuckOffProject.Clients
{
    public class FuckOffClient
    {
        string BasePath = "https://foaas.com/";
        public RestClient RestClient { get; set; }

        public RestClient ReturnClient (string endPoint)
        {
            RestClient client = new RestClient($"{ BasePath }{endPoint}");
            return client;
        }

        public RestRequest SetUp()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse Execute(string endPoint)
        {
            var client = ReturnClient(endPoint);
            var request = SetUp();
            var response = client.Execute(request);
            return response;
        }
    }
}
