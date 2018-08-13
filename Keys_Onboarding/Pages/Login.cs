using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Global
{

    public class Login : Base
    {
        //create constructor
        public Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }


        #region  Initialize Web Elements 
        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = ".//*[@id='login_email']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='login_password']")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button

        [FindsBy(How = How.XPath, Using = "//*[@id='login']/fieldset/div[4]/input")]
        private IWebElement loginButton { get; set; }

        #endregion

        internal void LoginSuccessfull()
        {
            //  try
            // {

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LoginPage");

            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));

            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));

            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(2, "Password"));

            // Clicking on the login button
            loginButton.Click();
            Driver.wait(5);
        }
    }
}
          /* catch (Exception e)
            {
                //logging the test results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Searching " + e.Message);
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
                
            }
            //Verification part
            string msg = "Update Account";
                  string Actualmsg = Driver.driver.FindElement(By.XPath(".//*[@id='content']/div[2]/div[2]/div/h1")).Text;

                 if (msg == Actualmsg)
                 {
                         //Logging test results  into extentreports
                         Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");

                         //screenshots
                         String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                         test.Log(LogStatus.Info, "Image example: " + img);

                         //returns'pass' once test passes
                        // return "Pass";
                     }


                     else
                     {
                         //logging test results
                         Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");
                         // screenshots
                         String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                         test.Log(LogStatus.Info, "Image example: " + img);
                       //  return "Fail";
                     }


                 }*/
                

           
   
    
