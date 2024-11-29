using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationexercise.com.Pages
{
    public class NewUserSignup
    {
        private readonly IWebDriver driver;

        public NewUserSignup(IWebDriver driver)
        {
           driver = driver;
        }
        private IWebElement TitleRadioButton => driver.FindElement(By.Id("id_gender1"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement days => driver.FindElement(By.Id("days"));
        private IWebElement month => driver.FindElement(By.Id("uniform-months"));
        private IWebElement year => driver.FindElement(By.Id("uniform-years"));
        private IWebElement Chkbox1 => driver.FindElement(By.Id("uniform-newsletter"));

        //Enter Address Information
        private IWebElement Firstname => driver.FindElement(By.Id("first_name"));
        private IWebElement Lastname => driver.FindElement(By.Id("last_name"));
        private IWebElement Company => driver.FindElement(By.Id("company"));
        private IWebElement Address1 => driver.FindElement(By.Id("address1"));
        private IWebElement Address2 => driver.FindElement(By.Id("address2"));
        private IWebElement Country => driver.FindElement(By.Id("country"));
        private IWebElement State => driver.FindElement(By.Id("state"));
        private IWebElement City => driver.FindElement(By.Id("city"));
        private IWebElement ZipCode => driver.FindElement(By.Id("zipcode"));
        private IWebElement MobileNumber => driver.FindElement(By.Id("mobile_number"));
        private IWebElement CreateButton => driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
        private IWebElement ClickContinue => driver.FindElement(By.XPath("//*[@data-qa='continue-button']"));
        public void NewLogin(string username, string password)
        {
            TitleRadioButton.Click();
            PasswordField.SendKeys("Test@1234");
            days.SendKeys("1");
            days.SendKeys(Keys.Enter);
            month.SendKeys("9");
            month.SendKeys(Keys.Enter);
            year.SendKeys("1997");
            year.SendKeys(Keys.Enter);
            Chkbox1.Click();
            Firstname.SendKeys("NewTest");
            Lastname.SendKeys("User1");
            Company.SendKeys("TEC");
            Address1.SendKeys("1-123,BTP,ATP");
            Address2.SendKeys("AP,123456");
            Country.SendKeys("India");
            Country.SendKeys(Keys.Enter);
            State.SendKeys("AP");
            City.SendKeys("ATP");
            ZipCode.SendKeys("123456");
            MobileNumber.SendKeys("1234567890");
            CreateButton.Click();
            ClickContinue.Click();
            //*[@data-qa='continue-button']
        }
    }
}
