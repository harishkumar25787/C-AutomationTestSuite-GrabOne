using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class MyAccount : Base
    {

        public MyAccount()
        {
            PageFactory.InitElements(Global.Driver.driver, this);

        }
        

        // Define user link
        [FindsBy(How = How.XPath, Using = ".//*[@id='banner-account-links']/ul/li[2]/div/button")]
        private IWebElement User { get; set; }

        //Define My Account button
        [FindsBy(How = How.XPath, Using = ".//*[@id='user-nav-account']/li[1]/a")]
        private IWebElement MyAcc { get; set; }

        //Define change button in name feild
        [FindsBy(How = How.XPath, Using = ".//*[@id='my-account']/div[1]/fieldset/form[1]/div[1]/div[1]/a[1]")]
        private IWebElement Namechange { get; set; }

        //Define First name
        [FindsBy(How = How.XPath, Using = ".//*[@id='account_first_name']")]
        private IWebElement Firstname { get; set; }
        // Define Lasr name
        [FindsBy(How = How.XPath, Using = ".//*[@id='account_last_name']")]
        private IWebElement Lastname { get; set; }
        // Define Submit button
        [FindsBy(How = How.XPath, Using = ".//*[@id='my-account']/div[1]/fieldset/form[1]/div[1]/div[2]/div[3]/span/input")]
        private IWebElement Submitname { get; set; }
        //Define chnge button in region
        [FindsBy(How = How.XPath, Using = ".//*[@id='my-account']/div[1]/fieldset/form[2]/div/div[1]/a[1]")]
        private IWebElement ChangeRegion { get; set; }
        //Define region
        [FindsBy(How = How.XPath, Using = ".//*[@id='region_default_area_id']")]
        private IWebElement Region { get; set; }
        // drfine submit button
        [FindsBy(How = How.XPath, Using = ".//*[@id='my-account']/div[1]/fieldset/form[2]/div/div[2]/div[2]/span/input")]
        private IWebElement SubmitRegion { get; set; }

        internal void Account()
        {

            User.Click();
            MyAcc.Click();
            Namechange.Click();
            ExcelLib.PopulateInCollection(Base.ExcelPath, "MyAccount");
            Firstname.Clear();
            Thread.Sleep(3000);
            Firstname.SendKeys(ExcelLib.ReadData(2, "Firstname"));
            Driver.wait(5);
            Lastname.Clear();
            Lastname.SendKeys(ExcelLib.ReadData(2, "Lastname"));
            Submitname.Click();


            ChangeRegion.Click();
            //select a region from dropdown
            Driver.wait(5);
              SelectElement reg = new SelectElement(Region);
             string regionval = ExcelLib.ReadData(2, "Region");
             reg.SelectByText(regionval);
           //Region.SendKeys(ExcelLib.ReadData(2, " Region"));
           // Global.Driver.WaitForElement(Driver.driver, By.XPath("html/body/div[8]"), 10);
           // Region.SendKeys(Keys.ArrowDown);
            //Region.SendKeys(Keys.Enter);


            Thread.Sleep(3000);
            SubmitRegion.Click();
            ValidateMyAcc();
        }

        //verification part
        internal void ValidateMyAcc()
        {
            try
            {
                Driver.wait(5);
                string msg = "your Region has been updated";
                string Actualmsg = Driver.driver.FindElement(By.XPath(".//*[@id='content']/div[1]/p")).Text;

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
