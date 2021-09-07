using APIAutomationTest.Api;
using Commons.Model;
using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIAutomationTest.Test
{
    class BillingOrder_CSVTest
    {

        [TestCaseSource("TestData")]
        public void CreateCSVBillingOrderTest(BillingOrder expectedOrder)
        {

            //convert object to json
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);

            //create new order record
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse postResponse = billingOrder.Create(jsonBody);

            //convert response json to object
            BillingOrder responseOrder = JsonConvert.DeserializeObject<BillingOrder>(postResponse.Content);
            TestContext.WriteLine(responseOrder.FirstName);
            TestContext.WriteLine(responseOrder.Id);

            //get the record
            IRestResponse getResponse = billingOrder.Get(responseOrder.Id);

            Assert.AreEqual(expectedOrder.FirstName, responseOrder.FirstName);
            responseOrder.Should().BeEquivalentTo(expectedOrder,
            options => options.Excluding(o => o.Id));

        }


        static IEnumerable<TestCaseData> TestData()
        {

            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\Name.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    BillingOrder order =
                        new BillingOrder(firstName: csv["firstname"],
                        lastName: csv["lastname"], email: csv["email"]);

                    yield return new TestCaseData(order).SetName("Billing order TC " + csv["firstname"]);
                }
            }
        }
    }
}
