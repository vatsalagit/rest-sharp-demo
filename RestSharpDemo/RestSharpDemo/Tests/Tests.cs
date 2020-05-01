using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using RestSharpDemo.Utilities;

namespace RestSharpDemo
{
    [TestFixture]
    public class Tests
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient(baseUrl: "https://reqres.in/");
        }

        [Test]
        public void SimpleGetRequestTest()
        {
            //Arrange
            _restRequest = new RestRequest(resource: "api/users/2", Method.GET);
            //Act
            var result  = _restClient.Execute(_restRequest).Content;
            //Assert
            Console.WriteLine("******* This is the response ****** "+ result);
        }
        
        [Test]
        public void VerifyTotalNumberOfRecords()
        {
            _restRequest = new RestRequest(resource: "api/users?page=2", Method.GET);
            var restResponse = _restClient.Execute(_restRequest);
            //deserialize the response using Inbuilt deserializer
            /*var jsonDeserializer = new JsonDeserializer();
            var response = jsonDeserializer.Deserialize<Dictionary<string, string>>(restResponse);
            Console.WriteLine("The deserialized value using Inbuilt Deserializer is "+response["total"]);
            Assert.That(response["total"], Is.EqualTo("12"), "The total using Inbuilt Deserializer doesn't match");*/
            var response1 = Helper.DeseriailzeResponse(restResponse);
            Console.WriteLine("+++++++++++++++"+response1["total"]+"++++++++++++++++");
            Assert.That(response1["total"], Is.EqualTo("12"), "The total using Inbuilt Deserializer doesn't match");
            //JObject - NewTonSoft
            /*JObject jObject = JObject.Parse(restResponse.Content);
            var finalOutput = jObject["total"];
            Console.WriteLine("The deserialized value using NewTon Soft is "+finalOutput);
            Assert.That(finalOutput?.ToString(), Is.EqualTo("12"), "The total using NewTon Soft doesn't match");*/

            var output = Helper.DeserializeResponseUsingJObject(restResponse);
            Console.WriteLine("+++++++++++++++"+output["total"]+"++++++++++++++++");
            Assert.That(output["total"]?.ToString(), Is.EqualTo("12"), "The total using NewTon Soft doesn't match");
        }

        [Test]
        public void GetRequestWithAuthentication()
        {
            _restClient.Authenticator = new HttpBasicAuthenticator(username:"eve.hotl@reqres.in", password:"cityslicka");
            _restRequest = new RestRequest(resource:"https://reqres.in/api/login",Method.GET);
            var response = _restClient.Execute(_restRequest);
            Console.WriteLine("Status Code: "+(int) response.StatusCode);
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [TearDown]
        public void Close()
        {
            Console.WriteLine("End of Test Suite");
        }
    }
}