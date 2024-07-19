using MiaplazaHomeAss.pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiaplazaHomeAss.pages.Utils;
using MiaplazaHomeAss.tests.TestData;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace MiaplazaHomeAss.tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;
        protected OnlineSchoolPage onlineSchoolPage;
        protected MOHSPage mOHOPage;
        protected FormPage formPage;
        protected TestDataModel testData;
        protected ExtentReports extent = null;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void ExtentReportStart()
        {

            try
            {
                extent = new ExtentReports();
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MiaplazaHomeAss.html");

                Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

                var htmlReporter = new ExtentHtmlReporter(reportPath);
                extent.AttachReporter(htmlReporter);

                Console.WriteLine($"ExtentReports initialized. Report will be saved to: {reportPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing ExtentReports: {ex.Message}");
                throw;
            }
        }

        [OneTimeTearDown]
        public void ExtentReportTearDown() 
        {
            extent.Flush();
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("baseUrl"));
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            testData = JsonReader.ReadJsonFile("TestData.json");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {

            try
            {
                // Check if the test failed
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    string screenshotFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", $"{TestContext.CurrentContext.Test.Name}.png");

                    Directory.CreateDirectory(Path.GetDirectoryName(screenshotFilePath));

                    test.AddScreenCaptureFromPath(screenshotFilePath);
                    test.Fail(TestContext.CurrentContext.Result.Message);
                }
                else
                {
                    test.Pass("Test passed.");
                }
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
