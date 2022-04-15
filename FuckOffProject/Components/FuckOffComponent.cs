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
        public async Task<IRestResponse> GenericFuckOff(string endPoint)
        {
            var request = _client.SetUpRestRequest(endPoint);
            var response = _client.Executes(request);
            var effOff = JsonConvert.DeserializeObject<FuckOffModel>(response.Result.Content);
            _context.FuckOffMessagingContext = effOff;
            return response.Result;
        }

        public async Task<ResultModel<FuckOffModel>> FuckOffByName( string endPoint)
        {
            var request = _client.SetUpRestRequest(endPoint);
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

        public async Task<IRestResponse> FuckOffEven(string endPoint)
        {
            var request = _client.SetUpRestRequest(endPoint);
            var response = _client.Executes(request);
            var effOffMessage = JsonConvert.DeserializeObject<FuckOffModel>(response.Result.Content);
            _context.FuckOffMessagingContext = effOffMessage;
            return response.Result;
        }

        public async Task<ResultModel<FuckOffModel>> GetChoiceAndCallEndPoint(string name, int endPointChooser)
        {
            var endPointName = FuckOffChooser(name, endPointChooser);
            var request = _client.SetUpRestRequest(endPointName);
            var response = await _client.Executes(request);
            var effOffMessage = JsonConvert.DeserializeObject<FuckOffModel>(response.Content);
            _context.FuckOffMessagingContext = effOffMessage;
            return new ResultModel<FuckOffModel>
            {
                IsSuccessStatusCode = response.IsSuccessful,
                Result = JsonConvert.DeserializeObject<FuckOffModel>(response.Content),
                StatusCode = response.StatusCode
            };
        }

        public string FuckOffChooser(string name, int endPointNum)
        {

            switch (endPointNum)
            {
                case 0:
                    return $"king/{name}/Server";
                case 1:
                    return "even/Server";
                case 2:
                    return "off";
                default:
                    return "off";
            }
        }

    }
}
