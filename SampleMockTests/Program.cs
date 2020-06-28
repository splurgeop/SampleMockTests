using RestSharp;
using System;

namespace SampleMockTests
{
    class Program
    {
        static void Main(string[] args)
        {
            mockobj obj = new mockobj()
            {
                httpRequest = new httpRequest() { body = "",method = "GET", path = "/api/abc/xyz"},
                httpResponse = new httpResponse() {statusCode =200}
                
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
    }

    public class httpRequest
    {
        public string body { get; set; } = string.Empty;

        public string method { get; set; }
        public string path { get; set; }
    }
    public class httpResponse
    {
        public object headers { get; set; } = "[{\"name\":\"Content-Type\",\"values\":[ \"application/json\" ]}]";//new Dictionary<string, string>() { { "content-type", "[application/json]" } };

        public string body { get; set; } = string.Empty;
        public int statusCode { get; set; } = 200;
    }

}
