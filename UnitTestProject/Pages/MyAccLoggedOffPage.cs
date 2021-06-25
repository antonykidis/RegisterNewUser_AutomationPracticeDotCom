using OpenQA.Selenium;
using System;

namespace UnitTestProject
{
    public class MyAccountLoggedOffPage:BaseClass.BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement EmailTextBox => WaitFindElement(this._Driver, By.Id("email"), 2);
        private IWebElement PassWordTextBox => WaitFindElement(this._Driver, By.Id("passwd"), 2);
        private IWebElement SubmitButton => WaitFindElement(this._Driver, By.Id("SubmitLogin"), 2);

        public MyAccountLoggedOffPage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        internal MyAccountPage Login_WithExistingUser(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PassWordTextBox.SendKeys(password);
            SubmitButton.Click();
            return new MyAccountPage(_Driver);
        }
    }
}