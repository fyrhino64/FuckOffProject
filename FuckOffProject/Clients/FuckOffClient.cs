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
        string BasePath = "https://foaas.com/off/";
        public RestClient RestClient { get; set; }

        public RestClient ReturnClient (string BasePath)
        {
            RestClient client = new RestClient(BasePath);
            return client;
        }

        public RestRequest SetUpGenericRequest()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public FuckOffModel GenericFuckOff()
        {
            var client = ReturnClient(BasePath);
            var request = SetUpGenericRequest();
            IRestResponse response = client.Execute(request);
            var effOff = JsonConvert.DeserializeObject<FuckOffModel>(response.Content);
            return effOff;
        }
    }
}
