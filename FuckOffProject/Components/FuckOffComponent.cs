using FuckOffProject.Clients;
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
        public bool GenericFuckOff()
        {
            var client = new FuckOffClient();

            //var request = client.ReturnClient()
            //IRestResponse response = client.Execute(request);
            //var effOff = JsonConvert.DeserializeObject<FuckOffModel>(response.Content);
            return true;
        }
    }
}
