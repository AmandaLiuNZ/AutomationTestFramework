using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomation.Framework
{
    public class BasePageTest
    {

        public IWebDriver driver;

        [SetUp]
        public void SetUp() => driver = new ChromeDriver();

        [TearDown]
        protected void TearDown() => driver.Quit();
        
        [Test]
        public void CreateRecord()
        {
            //driver.Navigate().GoToUrl("https://qaauto.co.nz/billing-order-form/");
            //driver.Manage().Window.Size = new System.Drawing.Size(698, 784);
            //driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
            //driver.FindElement(By.Id("wpforms-submit-locked-24")).Click();
            //driver.FindElement(By.Id("wpforms-24-field_0")).SendKeys("Amanda");
            //driver.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys("Liu");
            //driver.FindElement(By.Id("wpforms-24-field_1")).SendKeys("amanda@gmail.com");
            //driver.FindElement(By.Id("wpforms-24-field_3")).SendKeys("11 Dunkerron Ave");
            //driver.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys("Epsom");
            //driver.FindElement(By.Id("wpforms-24-field_3-city")).SendKeys("Auckland");
            //driver.FindElement(By.CssSelector(".choice-1 > .wpforms-field-label-inline")).Click();
            //driver.FindElement(By.Id("wpforms-24-field_6")).SendKeys("test");
            //driver.FindElement(By.Id("wpforms-submit-24")).Click();
        }
    }
}
