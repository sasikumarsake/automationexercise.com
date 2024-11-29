//1.Launch browser
//2.Navigate to url 'http://automationexercise.com'
//3. Verify that home page is visible successfully
//4. Click on 'Contact Us' button
//5. Verify 'GET IN TOUCH' is visible
//6. Enter name, email, subject and message
//7. Upload file
//8. Click 'Submit' button
//9. Click OK button
//10. Verify success message 'Success! Your details have been submitted successfully.' is visible
//11. Click 'Home' button and verify that landed to home page successfully

using automationexercise.com.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automationexercise.com.Tests
{
    [TestClass]
    public class TC6
    {
       private IWebDriver driver;
       private SignUpPage signUpPage; 
        
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            signUpPage = new SignUpPage(driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [TestMethod]
        public void ContactUsForm()
        {
            string url = "http://automationexercise.com";
            string HomePagetitle = "//h2[contains(text(),'Full-Fledged practice website for Automation Engineers')]";
            string ExpectedhomePage = "Full-Fledged practice website for Automation Engineers";
            string GetInTouchPath = "//h2[contains(text(),'Get In Touch')]";
            string ExpectedTextGTP = "GET IN TOUCH";
            string GITNamefieldPath = "//input[@data-qa='name']";
            string GITEmailfieldPath = "//input[@data-qa='email']";
            string GITSubjectPath = "//input[@data-qa='subject']";
            string GITSubjectMSG = "User Manual for Joint Venture Management";
            string GITMSGPath = "//textarea[@data-qa='message']";
            string GITmsg = "This user manual provides step-by-step instructions " +
                "to ensure smooth usage of the Joint Venture Management system. The system " +
                "facilitates adding, editing, and managing joint ventures, including agreements, amendments, and workflows.";
            string expectedSuccessmsg = "Success! Your details have been submitted successfully.";


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

                //4. Click on 'Contact Us' button
                driver.FindElement(By.LinkText("Contact us")).Click();

                //5. Verify 'GET IN TOUCH' is visible
                IWebElement verifyGetInTouch = driver.FindElement(By.XPath(GetInTouchPath));
                string verifygtptext = verifyGetInTouch.Text;
                Assert.IsTrue(verifygtptext.Contains(ExpectedTextGTP), $"Expected Value{verifygtptext} not found in header. Found: {verifygtptext}");

                Console.WriteLine($"The Expected Value is successfully validated, {verifygtptext}");

                //6. Enter name, email, subject and message
                driver.FindElement(By.XPath(GITNamefieldPath)).SendKeys("NewTestUser1");
                driver.FindElement(By.XPath(GITEmailfieldPath)).SendKeys("newtestuser1@gmail.com");
                driver.FindElement(By.XPath(GITSubjectPath)).SendKeys(GITSubjectMSG);
                driver.FindElement(By.XPath(GITMSGPath)).SendKeys(GITmsg);

                // 7. Upload file
                driver.FindElement(By.Name("upload_file")).SendKeys(@"C:\Users\sasi.kumar\OneDrive - Motherson Group\Desktop\1687906665555.jpg");

                //8. Click 'Submit' button
                driver.FindElement(By.XPath("//input[@data-qa='submit-button']")).Click();

                //9. Click OK button
                //driver.FindElement(By.XPath("")).Click();
                // Switch the control of 'driver' to the Alert from main Window
                IAlert simpleAlert = driver.SwitchTo().Alert();

                // '.Text' is used to get the text from the Alert
                String alertText = simpleAlert.Text;
                Console.WriteLine("Alert text is " + alertText);

                // '.Accept()' is used to accept the alert '(click on the Ok button)'
                simpleAlert.Accept();

                //10. Verify success message 'Success! Your details have been submitted successfully.' is visible
                IWebElement verifySuccess = driver.FindElement(By.XPath("//*[contains(text(),'Success! Your details have been submitted successfully.')]"));
                string SuccessMSG = verifySuccess.Text;
                Assert.IsTrue(SuccessMSG.Contains(expectedSuccessmsg), $"Expected Value{SuccessMSG} not found in header. Found: {SuccessMSG}");

                Console.WriteLine($"The Expected Value is successfully validated, {SuccessMSG}");

                //11. Click 'Home' button and verify that landed to home page successfully
                driver.FindElement(By.XPath("//span[contains(text(),' Home')]")).Click();

                Thread.Sleep(4000);
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
