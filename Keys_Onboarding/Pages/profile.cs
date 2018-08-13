using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class profile : Base
    {
        public profile()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        // Define user link
        [FindsBy(How = How.XPath, Using = ".//*[@id='banner-account-links']/ul/li[2]/div/button")]
        private IWebElement User { get; set; }

        //Define profile button
        [FindsBy(How = How.XPath, Using = "//*[@id='user - nav - account']/li[3]/a")]
            private IWebElement profilebutton { get; set; }
        //Define Gender button
        [FindsBy(How = How.XPath, Using = "//*[@id='profile_gender']")]
            private IWebElement gender { get; set; }
        //Define mobile feild
        [FindsBy(How = How.XPath, Using = "//*[@id='profile_mobile']")]
            private IWebElement mobile { get; set; }
        //Define checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='profile_categories_1619']")]
            private IWebElement checkfitness { get; set; }
        //updateprofile button
        [FindsBy(How = How.XPath, Using = "//*[@id='profile']/form/fieldset/div[17]/span/input")]
        private IWebElement updateprofile  { get; set; }

        internal void updateprofilebutton()
        {
            User.Click();
            profilebutton.Click();
            Driver.wait(5);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            SelectElement gen = new SelectElement(gender);
            string genval = ExcelLib.ReadData(2, "gender");
            gen.SelectByText(genval);
            Thread.Sleep(3000);
            mobile.SendKeys(ExcelLib.ReadData(2, "mobile"));
            checkfitness.Click();
            updateprofile.Click();
            validateprofilebutton();
        }
        internal void validateprofilebutton()
        {
            try
            {
                Driver.wait(5);
                string msg = "your profile has saved";
                string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='content']/div[1]/p/span")).Text;

                if (msg == Actualmsg)
                {
                    //Logging test results  into extentreports
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");

                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);


                }


                else
                {
                    //logging test results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");
                    // screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);

                }


            }

            catch (Exception e)
            {
                //logging test results
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Searching Rental properties" + e.Message);
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }

        }

    }

    }

