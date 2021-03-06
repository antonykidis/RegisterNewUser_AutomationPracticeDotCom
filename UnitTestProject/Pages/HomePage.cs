using OpenQA.Selenium;
using System;

namespace UnitTestProject
{
    public class HomePage : BaseClass.BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement LoginButton => WaitFindElement(_Driver, By.ClassName("login"), 2);
        private IWebElement EmailTextBox => _Driver.FindElement(By.Id("#email"));
        private IWebElement PasswordTextBox => _Driver.FindElement(By.Id("#passwd"));



        public HomePage(IWebDriver driver) //will get the initialized driver from the base class
        {
            this._Driver = driver;
        }

        public AuthenticationPage SignIn_ToAuthPage()
        {
            LoginButton.Click();
            return new AuthenticationPage(_Driver);
        }

        internal MyAccountPage Login_WithExistingUser(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            return new MyAccountPage(_Driver);
        }
    }
}