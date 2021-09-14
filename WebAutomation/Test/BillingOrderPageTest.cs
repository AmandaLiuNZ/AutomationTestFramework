using Commons.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomation.Framework;
using WebAutomation.Page;

namespace WebAutomation.Test
{
    class BillingOrderPageTest : BasePageTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp() {
            driver = new ChromeDriver();
//            driver.Url = "https://qaauto.co.nz/billing-order-form/";
        }
        

        [TearDown]
        protected void TearDown() => driver.Quit();

        [Test]
        public void CreateBillingOrderTest() {

            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FirstName("Amanda");
            orderPage.LastName("Liu");
        }

        [Test]
        public void CreateBillingOrderTestModel()
        {
            BillingOrder record = new BillingOrder(itemNumber:3);
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FillForm(record);
            orderPage.Submit();
        }
    }
}
