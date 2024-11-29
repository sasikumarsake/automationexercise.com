using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationexercise.com.Pages
{
    public class SignUpPage
    {
        private readonly IWebDriver driver;
        
        public SignUpPage (IWebDriver driver)
        {
           this.driver = driver;
        }
        private IWebElement UserField => driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
        private IWebElement PasswordField => driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));

        public void SingUP (string username, string password)
        {
            UserField.SendKeys("NewTestUser1");
            PasswordField.SendKeys("newtestuser1@gmail.com");
            LoginButton.Click();
        }

    }
}
