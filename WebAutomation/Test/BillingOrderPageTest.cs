using Commons.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomation.Framework;
using WebAutomation.Page;

namespace WebAutomation.Test
{
    class BillingOrderPageTest : BasePageTest
    {
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
            BillingOrder record = new BillingOrder(email:"");
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FillForm(record);
            orderPage.Submit();
        }
    }
}
