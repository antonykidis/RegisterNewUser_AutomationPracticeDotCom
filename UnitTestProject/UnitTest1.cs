using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
namespace UnitTestProject
{

    //#1 SignIn Home click_to > AuthenticationPage.
    //#2 AuthtenticatonPage click_to > CreateAccountPage.
    //#3 Register to > MyAccountPage
    //#4 Log off to > MyAccountLoggedOffPage
    //#5 MyAccLoggedOff  Login_to > MyAccPage 
    //#6 Assert

    [TestClass]
    public class UnitTest1 : BaseClass.BaseClass
    {
        string _FirstName = "Chupa";
        string _Lastname = "Kabra";
        //  string _Email = "chupa10@gmail.com"; 
        string _email_fromConfig = ConfigurationManager.AppSettings["Email"]; // This is the only property you have to change to register new user(If Exists, simply put here new email, and run the test!)
        string _Password = "chupa@123";
        string _Day = "13";
        string _Month = "February";
        string _Year = "1980";
        string _Company = "Chupa&Sons";
        string _Address = "ChupaStreet. POB 123";
        string _City = "Los Angeles";
        string _State = "California";
        string _AddInfo = "I like Snikers";
        string _MobilePhone = "0549967045";
        Random rnd = new Random();
        

        [TestMethod]
        public void TestMethod1()
        {
            AuthenticationPage AuthPage = new HomePage(base._Driver).SignIn_ToAuthPage();
            if (null == AuthPage.Login_ToCreateAnAccountPage(_email_fromConfig))
            {
                //If true The user Exists in database!
                //1.show Error message(optional)
                //2.Manipulate Email
                _email_fromConfig = rnd.Next(1,10000).ToString()+_email_fromConfig;
                //3.Start again with new Email :-)
                CreateAccountPage CreateAccPage = AuthPage.Login_ToCreateAnAccountPage2(_email_fromConfig);
                MyAccount MyAccPage = CreateAccPage.RegisterNewUser_And_GoToMyAccountPage(_FirstName, _Lastname, _email_fromConfig, _Password, _Day, _Month, _Year, _Company, _Address, _City, _State, _AddInfo, _MobilePhone); //provide your Unregisterd user
                MyAccountLoggedOff MyAccloggedOff = MyAccPage.LogOff_ToAccLoggedOff();
                MyAccPage = MyAccloggedOff.Login_WithExistingUser(_email_fromConfig, _Password); //verification

                //Assert here
                Assert.IsTrue(MyAccPage.Username.Text.Equals(_FirstName + " " + _Lastname));
            }
            else
            {
                //Works only if you start with fresh unique email(In web.config)
                CreateAccountPage CreateAccPage = AuthPage.Login_ToCreateAnAccountPage2(_email_fromConfig);
                MyAccount MyAccPage = CreateAccPage.RegisterNewUser_And_GoToMyAccountPage(_FirstName, _Lastname, _email_fromConfig, _Password, _Day, _Month, _Year, _Company, _Address, _City, _State, _AddInfo, _MobilePhone); //provide your Unregisterd user

                MyAccountLoggedOff MyAccloggedOff = MyAccPage.LogOff_ToAccLoggedOff();
                MyAccPage = MyAccloggedOff.Login_WithExistingUser(_email_fromConfig, _Password); //verification

                //Assert here
                Assert.IsTrue(MyAccPage.Username.Text.Equals(_FirstName + " " + _Lastname));
            }

        }
    }




}

