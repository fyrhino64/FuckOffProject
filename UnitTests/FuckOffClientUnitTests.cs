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

namespace FuckOffClientUnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class FuckOffUnitTests
    {
        public IClientInterface clientMock { get; private set; } = Substitute.For<IClientInterface>();
        public string endPoint { get; set; } = "off";

            [TestMethod]
            public async Task ExpectNamedFuckOff()
            {
                var mockResponse = AutoFaker.Generate<FuckOffProject.FuckOffModel>();
                var response = new RestResponse
                {
                    Content = JsonConvert.SerializeObject(mockResponse),
                    StatusCode = System.Net.HttpStatusCode.OK,
                    ResponseStatus = ResponseStatus.Completed
                };

                //var clientResponse = clientMock.Executes(endPoint).Returns(response);
                //Assert.IsNotNull(clientResponse, "mockClient did not return call as expected");
                //Assert.IsNotNull(clientResponse);
            }
        }
    }
