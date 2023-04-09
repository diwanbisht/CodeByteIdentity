using CodeByte.Core;
using CodeByte.ObjectsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CodeByte
{
    [TestClass]
    public class CoderByteTest : BaseSetupConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageSteps"/> class.
        /// </summary>
        /// <param name="baseSetupConfiguration">The Selenium context.</param>
        /*    public CoderByteTest(BaseSetupConfiguration baseSetupConfiguration) 
                : base()
            {
                this.homePage = new HomePage(this.Driver);
            }*/

        [TestMethod]
        public void ValidateValidUserLogin()
        {
            Dictionary<String, String> dicValues = ReadExcelData.ReadExcelRowByRow(1);
            string UserName = dicValues["UserName"];
            string Password = dicValues["Password"];
            new LoginPage(this.Driver).ValidateEnterUserNameAndPassword(UserName, Password);
            Assert.IsTrue(new DashBoardHomePage(this.Driver).ValidateDashBoardLoginPage("Welcome"), "Login Failed.......");
        }



        [TestMethod]
        public void ValidateInValidUserLogin()
        {
            Dictionary<String, String> dicValues = ReadExcelData.ReadExcelRowByRow(3);
            string UserName = dicValues["UserName"];
            string Password = dicValues["Password"];                   
            Assert.AreEqual("Invalid credentials", new LoginPage(this.Driver).ValidateInvalidLogin(UserName, Password), "Invalid Message is not visible");
        }

        [TestMethod]
        public void ValidateUserMyLeaveList()
        {
            Dictionary<String, String> dicValues = ReadExcelData.ReadExcelRowByRow(1);
            string UserName = dicValues["UserName"];
            string Password = dicValues["Password"];
            string UserLeaveListGrid = dicValues["UserLeaveList"];
            new LoginPage(this.Driver).ValidateEnterUserNameAndPassword(UserName, Password);
            Assert.IsTrue(new DashBoardHomePage(this.Driver).ValidateMyLeaveUserGrid(UserLeaveListGrid), "Login Failed.......");
        }

       
    }
}
