﻿//Test Case 2: Login User with correct email and password

using automationexercise.com.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationexercise.com.Tests
{
    [TestClass]
    public class TC2
    {
        private IWebDriver driver;
        private SignUpPage loginPage;
        private WebDriverWait wait;
       
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new SignUpPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // WebDriverWait initialization
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void LoginUserwithcorrectemailandpassword()
        {
            string URL = "https://automationexercise.com";
            string HomePageLocator = "//*[@id='slider-carousel']/div/div[1]/div[1]/h2";
            string expectedValue = "Full-Fledged practice website for Automation Engineers";
            string loginPageExpectedValue = "Login to your account";
            string Loggedinasusername = "//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a";
            string username = "NewTestUser1";

            try
            {
                //1. Launch browser
                //2. Navigate to url 'http://automationexercise.com'
                driver.Navigate().GoToUrl(URL);
                //loginPage.SingUP("UserField", "PasswordField");

                //3. Verify that home page is visible successfully                
                IWebElement verifyHomePage = driver.FindElement(By.XPath(HomePageLocator));
                string headerText = verifyHomePage.Text;
                Assert.IsTrue(headerText.Contains(expectedValue), $"Expected value {expectedValue} not found in header. Found: {headerText}");

                Console.WriteLine($"The Home Page validated successfully. Found value: {headerText}");

                //4. Click on 'Signup / Login' button
                driver.FindElement(By.XPath("//a[@href='/login']")).Click();

                //5. Verify 'Login to your account' is visible
                IWebElement verifyLoginAccount = driver.FindElement(By.XPath("//h2[contains(text(),'Login to your account')]"));
                string loginText = verifyLoginAccount.Text;
                Assert.IsTrue(loginText.Contains(loginPageExpectedValue), $"Expected value {loginPageExpectedValue} not found in header. Found: {loginText}");

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

                //9. Click 'Delete Account' button
                driver.FindElement(By.XPath("//a[@href='/delete_account']")).Click();

                //10. Verify that 'ACCOUNT DELETED!' is visible
                driver.FindElement(By.XPath("//*[@data-qa='continue-button']")).Click();
                //Assert.AreEqual("ACCOUNT DELETED!", driver.Title);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed Due to An Exception" + ex.Message);
            }

        }
        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
