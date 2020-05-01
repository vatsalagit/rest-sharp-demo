using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpDemo.Utilities
{
    public static class Helper
    {
        public static Dictionary<string,string> DeseriailzeResponse(IRestResponse restresponse)
        { var jsonObj = new JsonDeserializer().Deserialize<Dictionary<String,String>>(restresponse);
            return jsonObj;
        }

        public static JObject DeserializeResponseUsingJObject(IRestResponse restResponse)
        {
            JObject jObject = JObject.Parse(restResponse.Content);
            //var finalOutput = jObject["total"];
            //return finalOutput?.ToString();
            return jObject;
        }
    }
    
    
}