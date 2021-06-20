using OpenQA.Selenium;
using System;

namespace UnitTestProject
{
    public class MyAccount : BaseClass.BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement LogOffButton => WaitFindElement(this._Driver, By.CssSelector(".header_user_info>.logout"), 2);
        public IWebElement Username => this._Driver.FindElement(By.ClassName("account"));
        private IWebElement PassWord => WaitFindElement(this._Driver, By.CssSelector(".header_user_info>.logout"), 2);



        public MyAccount(IWebDriver driver)
        {
            this._Driver = driver;
        }



        public MyAccountLoggedOff LogOff_ToAccLoggedOff()
        {

            LogOffButton.Click();

            return new MyAccountLoggedOff(_Driver);
        }

       
    }
}