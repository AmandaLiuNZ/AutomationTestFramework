using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebAutomation.Framework;
using WebAutomation.Page;

namespace WebAutomation.Test
{
    class BillingOrderPageTestCSV : BasePageTest
    {
        //[Test]
        //public void CreateBillingOrderTest() {

        //    BillingOrderPage orderPage = new BillingOrderPage(driver);
        //    orderPage.Login();
        //    orderPage.FirstName("Amanda");
        //    orderPage.LastName("Liu");
        //}

        OpenQA.Selenium.IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
//            driver.Url = "https://qaauto.co.nz/billing-order-form/";
        }

        [TearDown]
        protected void TearDown() => driver.Quit();

        [TestCaseSource("TestData")]
        public void CreateBillingOrderTestModel(BillingOrder record)
        {
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FillForm(record);
            orderPage.Submit();
            orderPage.Validate();
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
