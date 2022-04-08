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

namespace FuckOffClientUnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class FuckOffUnitTests
    {
        public IFuckOffInterface clientMock { get; private set; } = Substitute.For<IFuckOffInterface>();
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

                 clientMock.Execute().Returns(response);
                //Assert.IsTrue();
                //Assert.IsNotNull(clientResponse.Content);
            }
        }
    }
