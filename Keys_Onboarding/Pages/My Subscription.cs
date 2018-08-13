using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class MySubscription : Base
    {

        public MySubscription()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        // Define user link
        [FindsBy(How = How.XPath, Using = ".//*[@id='banner-account-links']/ul/li[2]/div/button")]
        private IWebElement User { get; set; }

        //Define my subscription button
        [FindsBy(How = How.XPath, Using = ".//*[@id='user-nav-account']/li[4]/a")]
        private IWebElement MySub { get; set; }

        //Define Experience
        [FindsBy(How = How.XPath, Using = ".//*[@id='site_subscription_manager_subscriptions_site_subscription_9']")]
        private IWebElement Exper { get; set; }

        //Define Bottle
        [FindsBy(How = How.XPath, Using = ".//*[@id='site_subscription_manager_subscriptions_site_subscription_15']")]
        private IWebElement Bottle { get; set; }

        //Define Booknow
        [FindsBy(How = How.XPath, Using = ".//*[@id='site_subscription_manager_subscriptions_site_subscription_174']")]
        private IWebElement Booknow { get; set; }

        //Define Promotion
        [FindsBy(How = How.XPath, Using = ".//*[@id='site_subscription_manager_specials_specials']")]
        private IWebElement Promotion { get; set; }


        //Define Savechanges button
        [FindsBy(How = How.XPath, Using = ".//*[@id='change-subscriptions-submit']")]
        private IWebElement Save { get; set; }




        internal void TopDeals()
        {
            User.Click();
            MySub.Click();
            Exper.Click();
            Bottle.Click();
            Booknow.Click();
            Promotion.Click();
            Save.Click();
            ValidateMysub();
        }
        
        //verification part
        internal void ValidateMysub()
        {
            try
            {
                Driver.wait(5);
                string msg = "your changes have been made";
                string Actualmsg = Driver.driver.FindElement(By.XPath(".//*[@id='site_subscription_manager_specials_specials']")).Text;

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