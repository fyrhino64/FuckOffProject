using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject.Clients
{
     public static class AuthToken
    {
        public static string GetAuthToken()
        {
            string authToken = Environment.GetEnvironmentVariable("Spoonacular");
            return authToken;
        }   
    }
}
