//Test Case 5: Register User with existing email
//1. Launch browser
//2. Navigate to url 'http://automationexercise.com'
//3. Verify that home page is visible successfully
//4. Click on 'Signup / Login' button
//5. Verify 'New User Signup!' is visible
//6. Enter name and already registered email address
//7. Click 'Signup' button
//8. Verify error 'Email Address already exist!' is visible

using automationexercise.com.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationexercise.com.Tests
{
    [TestClass]
   public  class TC5
    {
        private IWebDriver driver;
        private SignUpPage singUpPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            singUpPage = new SignUpPage(driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

       
        }
        [TestMethod]
        public void RegisterUserwithexistingemail()
        {
            string url = "http://automationexercise.com";
            string HomePagetitle = "//h2[contains(text(),'Full-Fledged practice website for Automation Engineers')]";
            string ExpectedhomePage = "Full-Fledged practice website for Automation Engineers";
            string NewSignUpPagetitlePath = "//h2[contains(text(),'New User Signup!')]";
            string ExpectedSignUPPage = "New User Signup!";
            string validateerrorpath = "//*[@id='form']/div/div/div[3]/div/form/p";
            string expectederroris = "Email Address already exist!";

            try
            {
                //1. Launch browser
                //2.Navigate to url 'http://automationexercise.com'
                driver.Navigate().GoToUrl(url);

                //3. Verify that home page is visible successfully
                IWebElement verifyHomePage = driver.FindElement(By.XPath(HomePagetitle));
                string homepagetext = verifyHomePage.Text;
                Assert.IsTrue(homepagetext.Contains(ExpectedhomePage), $"Expected Value {ExpectedhomePage} not found in header. Found: {homepagetext}");

                Console.WriteLine($"The Error Is Validated Successfully: Found:, {homepagetext}");

              
                //4. Click on 'Signup / Login' button
                driver.FindElement(By.LinkText("Signup / Login")).Click();

                //5. Verify 'New User Signup!' is visible
                IWebElement verifyNewUserSignup = driver.FindElement(By.XPath(NewSignUpPagetitlePath));
                string NewUserSignUpText = verifyNewUserSignup.Text;
                Assert.IsTrue(NewUserSignUpText.Contains(ExpectedSignUPPage), $"Expected Value {ExpectedSignUPPage} not found in header. Found: {NewUserSignUpText}");

                Console.WriteLine($"The Error Is Validated Successfully: Found:, {NewUserSignUpText}");

                //6. Enter name and already registered email address
                driver.FindElement(By.XPath("//input[@data-qa='signup-name']")).SendKeys("NewTestUser1");
                driver.FindElement(By.XPath("//input[@data-qa='signup-email']")).SendKeys("newtestuser1@gmail.com");

                //7. Click 'Signup' button
                driver.FindElement(By.XPath("//button[@data-qa='signup-button']")).Click();

                //8. Verify error 'Email Address already exist!' is visible
                IWebElement verifyalreadyexisterror = driver.FindElement(By.XPath("//*[@id='form']/div/div/div[3]/div/form/p"));
                string errormessage = verifyalreadyexisterror.Text;
                Assert.IsTrue(errormessage.Contains(expectederroris), $"Expected Value {expectederroris} not found in header, Found: {errormessage}");

                Console.WriteLine($"The Error Email is Successfully validated:, {errormessage}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"The Test Execution is Failed Due to an Error, Found: {ex.Message}");
            }
        }
        [TestCleanup]
        public void CleanBrowser()
        {
            driver.Quit();
        }
    }
}
