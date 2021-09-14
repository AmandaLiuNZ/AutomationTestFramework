using Commons.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomation.Page
{
    public class BillingOrderPage :BasePage
    {
        IWebDriver driver;

        By _FirstName = By.Id("wpforms-24-field_0");
        By _LastName = By.Id("wpforms-24-field_0-last");
        By _Email = By.Id("wpforms-24-field_1");
        By _Phone = By.Id("wpforms-24-field_2");
        By _AddressLine1 = By.Id("wpforms-24-field_3");
        By _AddressLine2 = By.Id("wpforms-24-field_3-address2");
        By _City = By.Id("wpforms-24-field_3-city");
        By _State = By.Id("wpforms-24-field_3-state");
        By _ZipCode = By.Id("wpforms-24-field_3-postal");
        By _Item = By.Id("wpforms-24-field_4");
        By _Comments = By.Id("wpforms-24-field_6");
        By _password = By.Id("wpforms-locked-24-field_form_locker_password");
        By _loginsubmit = By.Id("wpforms-submit-locked-24");
        By _submit = By.Id("wpforms-submit-24");


        public BillingOrderPage(IWebDriver driver): base(driver)
        {
            Visit("https://qaauto.co.nz/billing-order-form/");

        }

        public void FirstName(string value) => Type(_FirstName,value);

        public void LastName(string value) => Type(_LastName,value);

        public void Email(string value) => Type(_Email,value);

        public void Phone(string value) =>Type(_Phone,value);
        public void AddressLine1(string value) => Type(_AddressLine1,value);

        public void AddressLine2(string value) => Type(_AddressLine2,value);

        public void City(string value) => Type(_City,value);

        public void State(string value) => Type(_State,value);

        public void ZipCode(string value) => Type(_ZipCode,value);

        //        public void Item(string value) => driver.FindElement(_Item).SendKeys(value);

        public void Item(int value)
        { 
            switch(value)
            {
                case 1:
                    Click(By.Id("wpforms-24-field_4_1"));
                    break;
                case 2:
                    Click(By.Id("wpforms-24-field_4_2"));
                    break;
                case 3:
                    Click(By.Id("wpforms-24-field_4_3"));
                    break;
            }        
        }

        public void Comments(string value) => Type(_Comments,value);

        public void Login() {
            Type(_password, "Testing");
            Click(_loginsubmit);
        }

        public void FillForm(BillingOrder order)
        {
            FirstName(order.FirstName);
            LastName(order.LastName);
            Email(order.Email);
            Phone(order.Phone);
            AddressLine1(order.AddressLine1);
            AddressLine2(order.AddressLine2);
            City(order.City);
            State(order.State);
            ZipCode(order.ZipCode);
            Item(order.ItemNumber);
            Comments(order.Comment);

        }

        public void Submit() => Click(_submit);

        public void Validate()
        {
            //Validate here
        }
    }
}
