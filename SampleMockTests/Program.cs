using RestSharp;
using System;
using System.Collections.Generic;

namespace SampleMockTests
{
    class Program
    {
        static void Main(string[] args)
        {
            mockobj obj = new mockobj()
            {
                httpRequest = new httpRequest() { body = "",method = "GET", path = "/aipii/abc/xyz"},
                httpResponse = new httpResponse() {statusCode =200,headers ="{\"name\":\"Content-Type\",  \"values\":[ \"application/json\" ]}" }

                
               //httpResponse= {"headers":"[{"name": "Content-Type",  "values": [ "application/json" ]}]","body":"{"Id":"5a02000a-ee8b-47a8-8e01-04ed7afe6263","Name":"firstTenanttwo", "Exists":"true"}","statusCode":200}

            };
            Console.WriteLine("Hello World!");
            RestClient rest = new RestClient("http://localhost:1080/mockserver/");
            RestRequest request = new RestRequest("expectation");
            request.Method = Method.PUT;
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(obj);
            IRestResponse restResponse = rest.Execute(request);
            
            Console.WriteLine(restResponse.StatusCode);

        }
    }
    public class mockobj
    {
       public httpRequest httpRequest { get; set; }
        public httpResponse httpResponse { get; set; }

        public override string ToString()
        {

            return string.Concat(httpRequest.ToString(), httpResponse.ToString());
        }
    }

    public class httpRequest
    {
        public string body { get; set; } = string.Empty;

        public string method { get; set; }
        public string path { get; set; }
    }
    public class httpResponse
    {
        public object headers { get; set; }//new Dictionary<string, string>() { { "content-type", "[application/json]" } };

        public string body { get; set; } = string.Empty;
        public int statusCode { get; set; } = 200;
    }

}
