using CodeByte.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace CodeByte.ObjectsRepo
{
    public class DashBoardHomePage
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashBoardHomePage"/> class.
        /// </summary>
        /// <param name="driver">The Driver.</param>
        public DashBoardHomePage(IWebDriver driver) => this.driver = driver;

        /// <summary>
        /// Gets element for Welcome Tag on  Dashboard screen.
        /// </summary>
        private IWebElement WelComeTag => this.driver.FindElement(By.XPath("//a[@id='welcome']"));

        /// <summary>
        /// Gets element for Logout Button on  Dashboard screen..
        /// </summary>
        private IWebElement Logout => this.driver.FindElement(By.XPath("//*[contains(text(),'Logout')]"));


        /// <summary>
        /// Gets element for My Leave -Tag Image/Span under Dashboard screen..
        /// </summary>
        private IWebElement MyLeaveQuickLaunch => this.driver.FindElement(By.XPath("//span[contains(text(),'My Leave')]"));

        /// <summary>
        /// Gets element for My Leave Data Grid on Dashboard screen..
        /// </summary>
        private IWebElement MyLeaveListGrid => this.driver.FindElement(By.XPath("//div/h1[contains(text(),'My Leave List')]"));

        public void UserLogOut()
        {
            this.WelComeTag.Click();
            BaseSetupConfiguration.ClickElement(this.Logout);
        }

        /// <summary>
        /// Validate DashBoard Logged in Page.
        /// </summary>

        public bool ValidateDashBoardLoginPage(String SuccessfullyLoginWelcomeTag)
        {
            string value = this.WelComeTag.Text;
            if (value.Contains(SuccessfullyLoginWelcomeTag))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Validate My leave User Grid on DashBoard Page.
        /// </summary>
        public bool ValidateMyLeaveUserGrid(string MyLeaveGridList)
        {
            BaseSetupConfiguration.ClickElement(this.MyLeaveQuickLaunch);
            string myLeavInfoGrid = this.MyLeaveListGrid.Text;
            if (myLeavInfoGrid.Contains(MyLeaveGridList))
            {
                return true;
            }
            else { return false; }
        }

    }
}
