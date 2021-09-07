using Commons.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomation.Page
{
    public class BillingOrderPage
    {
        IWebDriver driver;
        

        public BillingOrderPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Url = "https://qaauto.co.nz/billing-order-form/";

        }

        public void FirstName(string value) => driver.FindElement(By.Id("wpforms-24-field_0")).SendKeys(value);

        public void LastName(string value) => driver.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys(value);

        public void Email(string value) => driver.FindElement(By.Id("wpforms-24-field_1")).SendKeys(value);

        public void Phone(string value) =>driver.FindElement(By.Id("wpforms-24-field_2")).SendKeys(value);
        public void AddressLine1(string value) => driver.FindElement(By.Id("wpforms-24-field_3")).SendKeys(value);

        public void AddressLine2(string value) => driver.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys(value);

        public void City(string value) => driver.FindElement(By.Id("wpforms-24-field_3-city")).SendKeys(value);

        public void State(string value) => driver.FindElement(By.Id("wpforms-24-field_3-state")).SendKeys(value);


        public void ZipCode(string value) => driver.FindElement(By.Id("wpforms-24-field_3-postal")).SendKeys(value);

        public void Item(string value) => driver.FindElement(By.Id("wpforms-24-field_4")).SendKeys(value);

        public void Comments(string value) => driver.FindElement(By.Id("wpforms-24-field_6")).SendKeys(value);

        public void Login() {
            driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
            driver.FindElement(By.Id("wpforms-submit-locked-24")).Click();
        }

        public void FillForm(BillingOrder order)
        {
            FirstName(order.FirstName);
            LastName(order.LastName);
            Email(order.Email);
            AddressLine1(order.AddressLine1);
            AddressLine2(order.AddressLine2);
            Comments(order.Comment);

        }

        public void Submit() => driver.FindElement(By.Id("wpforms-submit-24")).Click();
    }
}
