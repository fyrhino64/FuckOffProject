using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using AutoBogus;
using FuckOffProject.Clients;
using NSubstitute;
using RestSharp;
using Newtonsoft.Json;
using Assert = NUnit.Framework.Assert;

namespace FuckOffProject.UnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class FuckOffUnitTests
    {
        public FuckOffClient client { get; private set; } = Substitute.For<FuckOffClient>();

        [TestMethod]
        public async Task ExpectNamedFuckOff()
        {
            var name = AutoFaker.Generate<string>();
            var mockResponse = AutoFaker.Generate<FuckOffModel>();
            var response = new RestResponse
            {
                Content = JsonConvert.SerializeObject(mockResponse),
                StatusCode = System.Net.HttpStatusCode.OK,
                ResponseStatus = ResponseStatus.Completed
            };

            //var clientResponse = client.GenericFuckOff().Returns(response);
            //Assert.IsTrue(clientResponse);
            //Assert.IsNotNull(clientResponse.Content);
        }
    }
}
