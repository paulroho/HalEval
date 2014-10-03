using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace HalEval.Tests
{
    [TestClass]
    public class Playground
    {
        private HttpClient _client;
        private HttpServer _server;

        [TestInitialize]
        public void SetupServerAndClient()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            HalConfig.Register(config);
            _server = new HttpServer(config);
            _client = new HttpClient(_server) { BaseAddress = new Uri("http://anything") };
            _client.DefaultRequestHeaders.Add("Accept", "application/hal+json");
        }

        [TestCleanup]
        public void CleanupClientAndServer()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [TestMethod]
        public void GetAPerson_Self_ReturnsTheSameResource()
        {
            var personRep = GetObjectFromService("api/Persons/1");

            var selfHref = personRep["_links"]["self"]["href"];
            var selfHrefString = (string)selfHref;

            var personFromSelf = GetObjectFromService(selfHrefString);
            var selfHrefFromSelf = personFromSelf["_links"]["self"]["href"];

            Assert.AreEqual(selfHref, selfHrefFromSelf);
        }

        private JObject GetObjectFromService(string uri)
        {
            var response = _client.GetAsync(uri).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            return JObject.Parse(result);
        }
    }

}