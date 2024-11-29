//Test Case 4: Logout User

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
    public class TC4
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
        public void LogoutUser()
        {
            string url = "http://automationexercise.com";
            string HomePagetitle = "//h2[contains(text(),'Full-Fledged practice website for Automation Engineers')]";
            string ExpectedhomePage = "Full-Fledged practice website for Automation Engineers";
            string LoginPagePath = "//h2[contains(text(),'Login to your account')]";
            string expectedLoginpageTitle = "Login to your account";
            string Loggedinasusername = "//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a";
            string username = "NewTestUser1";
           


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

                //5. Verify 'Login to your account' is visible
                IWebElement loginPageVerify = driver.FindElement(By.XPath(LoginPagePath));
                string loginpagetext = loginPageVerify.Text;
                Assert.IsTrue(loginpagetext.Contains(expectedLoginpageTitle), $"Expected Value {expectedLoginpageTitle} not found in header. Found: {loginpagetext}");
                Console.WriteLine($"The loginpage verificatiino done successfullly, Found Value : ", loginpagetext);

                //6. Enter correct email address and password
                driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys("newtestuser1@gmail.com");
                driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys("Test@1234");

                //7.Click 'login' button
                driver.FindElement(By.XPath("//button[@data-qa='login-button']")).Click();


                //8. Verify that 'Logged in as username' is visible               
                IWebElement headerElement = driver.FindElement(By.XPath(Loggedinasusername));
                string LoggedUsername = headerElement.Text;
                Assert.IsTrue(LoggedUsername.Contains(username), $"Expected value {username} not found in header. Found: {LoggedUsername}");

                Console.WriteLine($"The Logged Username validated successfully. Found value: {LoggedUsername}");

                //9. Click 'Logout' button
                driver.FindElement(By.LinkText("Logout")).Click();

                //10. Verify that user is navigated to login page
                IWebElement navigateloginPage = driver.FindElement(By.XPath(LoginPagePath));
                string Navloginpagetext = navigateloginPage.Text;
                Assert.IsTrue(Navloginpagetext.Contains(expectedLoginpageTitle), $"Expected Value {expectedLoginpageTitle} not found in header. Found: {Navloginpagetext}");
                Console.WriteLine($"The loginpage verificatiino done successfullly, Found Value : ", Navloginpagetext);
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
