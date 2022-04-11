using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FuckOffProject.Clients
{
    public interface IFuckOffInterface
    {
        public RestClient RestClient { get; set; }

        public Task<IRestResponse> Execute(string args);
    }

    
}
