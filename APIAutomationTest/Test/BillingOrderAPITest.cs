using APIAutomationTest.Api;
using Commons.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomationTest
{
    class BillingOrderApiTest
    {
        /*string jsonBody = "{\"addressLine1\":\"address1\",\"addressLine2\":\"add2\"," +
            "\"city\":\"auckland\",\"comment\":\"testcomment\",\"email\":\"ajit@sector36.com\"," +
            "\"firstName\":\"Ajit\",\"itemNumber\":0,\"lastName\":\"Sharma\"," +
            "\"phone\":\"0123456789\",\"state\":\"AL\",\"zipCode\":\"121212\"}";*/

        [Test]
        public void CreateBillingOrderTest() {

            BillingOrder expectedOrder = new BillingOrder
            {
                AddressLine1 = "11 Dunkerron Ave",
                AddressLine2 = "Epsom",
                City = "Auckland",
                Comment = "test comment",
                Email = "amanda@gmail.com",
                FirstName = "Amanda",
                LastName = "Liu",
                ItemNumber = 1,
                Phone = "0210890873",
                State = "AL",
                ZipCode = "100051"
            };

            //convert object to json
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);

            //create new order record
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse postResponse = billingOrder.Create(jsonBody);

            //convert response json to object
            BillingOrder responseOrder= JsonConvert.DeserializeObject<BillingOrder>(postResponse.Content);
            TestContext.WriteLine(responseOrder.FirstName);
            TestContext.WriteLine(responseOrder.Id);

            //get the record
            IRestResponse getResponse = billingOrder.Get(responseOrder.Id);

            Assert.AreEqual(expectedOrder.FirstName, responseOrder.FirstName);
            responseOrder.Should().BeEquivalentTo(expectedOrder, 
            options => options.Excluding(o => o.Id));

        }
    }
}
