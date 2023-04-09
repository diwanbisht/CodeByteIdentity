using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeByte.Core
{
    public class BaseSetupConfiguration
    {
       
        public ExtentTest test { get; set; }

        public IWebDriver driver { get; set; }
        public TestContext TestContext { get; set; }

        public BaseSetupConfiguration()
        {
            this.driver = driver;
        }
     

        [ClassInitialize]
        public void ClassInitilizer()
        {
           
        }

    
        [TestInitialize]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            var BaseUrl = ReadExcelData.ReadExcelRowByRow(2);
            driver.Navigate().GoToUrl(BaseUrl["BaseUrl"].ToString());
            // driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings.Get("BaseUrl"));
        }


        [TestCleanup]
        public void QuitDriver()
        {
            if (driver != null)
                driver.Quit();
        }

        public IWebDriver Driver
         {
             get { return driver; }
         }


        public static void ClickElement(IWebElement element)
        {
            element.Click();
            //SoftAssert soft = new SoftAssert();

        }


    }
}