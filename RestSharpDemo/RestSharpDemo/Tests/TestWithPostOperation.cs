using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Model;
using RestSharpDemo.Utilities;

namespace RestSharpDemo
{
    [TestFixture]
    public class TestWithPostOperation
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        
      /*  [SetUp]
        public void Setup()
        {
            _restClient = new RestClient(baseUrl: "https://reqres.in/");
        }*/

      //  [Test]
       /* public void TestWithPostCall()
        {
           _restRequest = new RestRequest( resource:"api/users", Method.POST);
            //Console.WriteLine("**************** "+_restRequest);
            _restRequest.AddJsonBody(new {name = "abc"});
            _restRequest.AddJsonBody(new {job = "efg"});
            var result = _restClient.Execute(_restRequest);

            var rresult = Helper.DeseriailzeResponse(result);
            var name = rresult["name"];
            Assert.That(name, Is.EqualTo("abc"));
            
         

        }*/

        [Test]
        public void Test1()
        {
            _restClient = new RestClient("http://dummy.restapiexample.com/");
            _restRequest = new RestRequest("api/v1/create" , Method.POST);
            _restRequest.AddJsonBody(new {name = "morpheus"});
            _restRequest.AddJsonBody(new {salary = 5000 });
            _restRequest.AddJsonBody(new {age = 30 });

        var result = _restClient.Execute(_restRequest);
            
            // using regular deserializer
            var rResult = Helper.DeseriailzeResponse(result);
            var status = rResult["status"];
            Console.WriteLine("Status is "+status);
            Assert.That(status, Is.EqualTo("success"));

            //var ddata = Helper.DeseriailzeResponse(rResult["data"]);

            // using newtonsoft deserializer
            var jResult = Helper.DeserializeResponseUsingJObject(result);
            Assert.That(jResult["status"]?.ToString(), Is.EqualTo("success"));
            Assert.That(jResult["data"]?["name"]?.ToString(), Is.EqualTo("morpheus"));
            
        }
        //Test POST with Type class
        [Test]
        public void TestPostWithTypeClass()
        { _restClient = new RestClient(baseUrl: "https://reqres.in/");
            _restRequest = new RestRequest("api/register", Method.POST);
        _restRequest.AddJsonBody(new Users() {email = "eve.holt@reqres.in", password = "pistol"});
        var result = _restClient.Execute<Users>(_restRequest);
        //read about extension methods
        //read about pojo and singleton classes
        //poco class
        Assert.That(result.Data.token, Is.EqualTo("QpwL5tke4Pnpja7X4"));
        Console.WriteLine(result.Data.token);
        Console.WriteLine(result.Data.email);
        }

        [Test]
        public void TestNestedJson()
        { 
            _restClient = new RestClient("http://dummy.restapiexample.com/");
            _restRequest = new RestRequest("api/v1/create" , Method.POST);
           // _restRequest.AddJsonBody(new {salary = "5000" });
            //_restRequest.AddJsonBody(new {name = "morpheus"});
            //_restRequest.AddJsonBody(new {age = "30" });
            _restRequest.AddJsonBody(new EmployeeDetail() {name = "morpheus", salary = "5000", age = "30"});
            var result = _restClient.Execute<CreatEmployeeResponse>(_restRequest);
            Console.WriteLine(result.Data.status);
            Console.WriteLine(result.Data.data.name);
            Console.WriteLine(result.Data.data.age);
            Console.WriteLine(result.Data.data.salary);
            Assert.That(result.Data.data.name, Is.EqualTo("morpheus"));

        }

    }
}