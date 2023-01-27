using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
namespace Booking_web_Search.HelperFunctions
{
    public class BasePageObject
    {
        protected IWebDriver driver { get; set; }

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        protected void VerifyPageLoaded(By by)
        {

             new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
    }

}
