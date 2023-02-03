using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Booking_web_Search.HelperFunctions
{
    public static class BasePageObject
    {


        public static IWebDriver driver { get; set; }

        public static void StartTest(string BaseURL)
        {
            try
            {

                ChromeOptions ChromeOptions = new ChromeOptions();
                ChromeOptions.AddArguments("--start-maximized");
                ChromeOptions.AddArguments("--no-sandbox");
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ChromeOptions);
                driver.Navigate().GoToUrl(BaseURL);
                Console.WriteLine("Browser loaded, Test Passed");
            }
            catch (Exception testInitiationException)
            {
                Console.WriteLine("Failed Initiation : {0}", testInitiationException.Message);

            }
        }

        public static void CloseTest()
        {
            try
            {
                driver.Quit();

                Console.WriteLine("Test Completes successfully");
            }
            catch (WebDriverException testClosingException)
            {
                Console.WriteLine("Driver Failed to close the browser: {0}", testClosingException.Message);
            }
        }

      

    }
}
