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
            var response = _client.Execute("off");
            var effOff = JsonConvert.DeserializeObject<FuckOffModel>(response.Content);
            _context.FuckOffMessagingContext = effOff;
            return response;
        }

        public async Task<ResultModel<FuckOffModel>> FuckOffByName(string name)
        {
            var response = _client.Execute($"king/{name}/Server");
            var effOffMessage = JsonConvert.DeserializeObject<FuckOffModel>(response.Content);
            _context.FuckOffMessagingContext = effOffMessage;
            return new ResultModel<FuckOffModel>
            {
                IsSuccessStatusCode = response.IsSuccessful,
                Result = JsonConvert.DeserializeObject<FuckOffModel>(response.Content),
                StatusCode = response.StatusCode
            };
        }

    }
}
