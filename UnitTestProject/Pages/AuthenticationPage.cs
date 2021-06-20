﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace UnitTestProject
{
    public class AuthenticationPage : BaseClass.BaseClass // BaseClass serves WaitFindelement() method
    {
        //Properties
        private IWebDriver _Driver;
        private IWebElement EmailTextBox => WaitFindElement(this._Driver, By.CssSelector(".form-group>.is_required#email_create"), 3);
        private IWebElement SubmitButton => WaitFindElement(this._Driver, By.CssSelector(".form_content >.submit>#SubmitCreate"), 3);
        private IWebElement ErroMessage => WaitFindElement(this._Driver, By.CssSelector("#create_account_error"), 3);

        public AuthenticationPage(IWebDriver driver)
        {
            this._Driver = driver;
        }


        public CreateAccountPage Login_ToCreateAnAccountPage(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(4000);
       
            if (ErroMessage.Text.Length > 0)
            {
                return null;
            }
            else
            {
                return new CreateAccountPage(_Driver); //Passing driver to the next page

            }



        }
        public CreateAccountPage Login_ToCreateAnAccountPage2(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(4000);
            if (this._Driver.Url.Equals("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation"))
            {
                return new CreateAccountPage(_Driver); //Passing driver to the next page

            }

            return null;

        }

    }
}