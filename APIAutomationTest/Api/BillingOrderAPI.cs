using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomationTest.Api
{
    class BillingOrderAPI
    {
        string baseUrl = "http://localhost:8181/BillingOrder/";

        public IRestResponse GetALL() {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            return client.Execute(request);

        }

        public IRestResponse Create(string body) {

            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            return client.Execute(request);

        }

        public IRestResponse Update(int id, string body) {

            var client = new RestClient($"{baseUrl}/{id}");
            var request = new RestRequest(Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            return client.Execute(request);

        }
        public IRestResponse Delete(int id) {

            var client = new RestClient($"{baseUrl}/{id}");
            var request = new RestRequest(Method.DELETE);

            request.AddHeader("Content-Type", "application/json");
            return client.Execute(request);

        }
        public IRestResponse Get(int id) {

            var client = new RestClient($"{baseUrl}/{id}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            return client.Execute(request);

        }


    }
}
