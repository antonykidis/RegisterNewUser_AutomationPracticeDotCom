using OpenQA.Selenium;
using System;

namespace UnitTestProject
{
    public class MyAccountPage : BaseClass.BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement LogOffButton => WaitFindElement(this._Driver, By.CssSelector(".header_user_info>.logout"), 2);
        public IWebElement Username => this._Driver.FindElement(By.ClassName("account"));
        private IWebElement PassWord => WaitFindElement(this._Driver, By.CssSelector(".header_user_info>.logout"), 2);



        public MyAccountPage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        public MyAccountLoggedOffPage LogOff_ToAccLoggedOff()
        {

            LogOffButton.Click();

            return new MyAccountLoggedOffPage(_Driver);
        }

       
    }
}