using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Test
{
    class sprint1
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Base
        {
            [Test, Description("my subscription functionality")]
            public void MYsubscrip()
            {
                // Creates a toggle for the given test, adds all log events under it    
              test = extent.StartTest("subscription", "verify user able to subscribe various functionality of Grabone");
                MySubscription MYsubobj = new MySubscription();
                MYsubobj.TopDeals();

            }

            [Test, Description("my Account functionality")]
            public void MYAcco()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("my account", "verify user able to save his account in Grabone");
                MyAccount MYacctobj = new MyAccount();
                MYacctobj.Account();

            }

            [Test, Description("my update profile functionality")]
            public void updprofile()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("profile", "verify user able to updateprofile in Grabone");
                profile proobj = new profile();
                proobj.updateprofilebutton();

            }
        }
    }
}
