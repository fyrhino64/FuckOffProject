using FuckOffProject.Clients;
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
    public class FuckOffComponent
    {
        private readonly FuckOffMessageContext _context;
        private readonly FuckOffClient _client;
        public FuckOffComponent(FuckOffMessageContext context, FuckOffClient client)
        {
            _context = context;
            _client = client;
        }
        public async Task<IRestResponse> GenericFuckOff()
        {
            var request = _client.SetUpRestRequest("off");
            var response = _client.Executes(request);
            var effOff = JsonConvert.DeserializeObject<FuckOffModel>(response.Result.Content);
            _context.FuckOffMessagingContext = effOff;
            return response.Result;
        }

        public async Task<ResultModel<FuckOffModel>> FuckOffByName(string name)
        {
            var request = _client.SetUpRestRequest($"king/{name}/Server");
            var response = _client.Executes(request);
            var effOffMessage = JsonConvert.DeserializeObject<FuckOffModel>(response.Result.Content);
            _context.FuckOffMessagingContext = effOffMessage;
            return new ResultModel<FuckOffModel>
            {
                IsSuccessStatusCode = response.Result.IsSuccessful,
                Result = JsonConvert.DeserializeObject<FuckOffModel>(response.Result.Content),
                StatusCode = response.Result.StatusCode
            };
        }

    }
}
