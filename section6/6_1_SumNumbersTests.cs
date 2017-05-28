using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Configuration;
using System.Net;

namespace AzureFunctionUnitTests
{
    [TestClass]
    public class SumNumbersTests
    {
        [TestMethod]
        public void Get_WithNum1AndNum2Undefined_ErrorResponse()
        {
            var client = MakeClient();
            var request = MakeRequestSum();
            var response = client.Get(request);
            Assert.AreEqual("\"Please pass in num1 on the query string or in the request body\"", response.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Get_WithNum1DefinedButNoNum2_ErrorResponse()
        {
            var client = MakeClient();
            var request = MakeRequestSum();
            request.AddQueryParameter("num1", "1");
            var response = client.Get(request);
            Assert.AreEqual("\"Please pass in num2 on the query string or in the request body\"", response.Content);
        }

        [TestMethod]
        public void Get_WithNums1And2_ReturnsSumWhichIs3()
        {
            var client = MakeClient();
            var request = MakeRequestSum();
            request.AddQueryParameter("num1", "1");
            request.AddQueryParameter("num2", "2");
            var response = client.Get(request);
            Assert.AreEqual("3", response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private IRestClient MakeClient()
        {
            var urlBase = ConfigurationManager.AppSettings["urlBase"];
            var client = new RestClient(urlBase);
            return client;
        }

        private IRestRequest MakeRequestSum()
        {
            var appKey = ConfigurationManager.AppSettings["functionAppKey"];
            var sumFunctionName = ConfigurationManager.AppSettings["sumFunctionName"];
            var request = new RestRequest(sumFunctionName, Method.GET);
            request.AddQueryParameter("code", appKey);
            return request;
        }
    }
}
