using automationexercise.com.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace automationexercise.com.Tests
{
    [TestClass]
    public class TC1
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private SignUpPage _loginPage;

        [TestInitialize]
        public void SetUP()
        {
            _driver = new ChromeDriver();
            _loginPage = new SignUpPage(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // WebDriverWait initialization
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Register_User()
        {
            string url = "https://automationexercise.com/login";
            string Loggedinasusername = "//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a";
            string expectedValue = "NewTestUser1";
            try
            {
                _driver.Navigate().GoToUrl(url);
                _loginPage.SingUP("UserField", "PasswordField");

                // Wait for the radio button to be clickable
                IWebElement TitleRadioButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("id_gender1")));
                TitleRadioButton.Click();

                // Wait for password field and enter password
                IWebElement PasswordField = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("password")));
                PasswordField.SendKeys("Test@1234");

                // Select Date of Birth
                SelectElement DaysSelect = new SelectElement(_driver.FindElement(By.XPath("//select[@data-qa='days']")));
                DaysSelect.SelectByValue("1");

                SelectElement monthSelect = new SelectElement(_driver.FindElement(By.XPath("//select[@data-qa='months']")));
                monthSelect.SelectByValue("9");
                

                SelectElement yearSelect = new SelectElement(_driver.FindElement(By.XPath("//select[@data-qa='years']")));
                yearSelect.SelectByValue("1997");
                //year.SendKeys(Keys.Enter);

                // Wait for checkbox and click
                //_driver.FindElement(By.Id("uniform-newsletter")).Click();

                // Enter Address Information
                _driver.FindElement(By.Id("first_name")).SendKeys("NewTest");


                _driver.FindElement(By.Id("last_name")).SendKeys("User1");


                _driver.FindElement(By.Id("company")).SendKeys("TEC");


                _driver.FindElement(By.Id("address1")).SendKeys("1-123,BTP,ATP");


                _driver.FindElement(By.Id("address2")).SendKeys("AP,123456");
                

                IWebElement Country = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("country")));
                Country.SendKeys("India");
                Country.SendKeys(Keys.Enter);

                _driver.FindElement(By.Id("state")).SendKeys("AP");


                _driver.FindElement(By.Id("city")).SendKeys("ATP");


                _driver.FindElement(By.Id("zipcode")).SendKeys("123456");


                _driver.FindElement(By.Id("mobile_number")).SendKeys("1234567890");

                _driver.FindElement(By.XPath("//button[@data-qa='create-account']")).Click();


                // Wait for the continue button to be clickable and then click
                _driver.FindElement(By.XPath("//*[@data-qa='continue-button']")).Click();

                //Verify that 'Logged in as username' is visible
                IWebElement headerElement = _driver.FindElement(By.XPath(Loggedinasusername));
                string LoggedUsername = headerElement.Text;
                Assert.IsTrue(LoggedUsername.Contains(expectedValue), $"Expected value {expectedValue} not found in header. Found: {LoggedUsername}");
                //a[@data-qa='continue-button']

                //17.Click 'Delete Account' button
               // _driver.FindElement(By.XPath("//a[@href='/delete_account']")).Click();

                //18.Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
               // _driver.FindElement(By.XPath("//*[@data-qa='continue-button']")).Click();
              
                
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed due to an exception: " + ex.Message);
            }
        }

        // Cleanup method to close the WebDriver after the test
        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}
