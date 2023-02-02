using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.ExtendedProperties;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Internal;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Booking_web_Search.Extensions;
using System.Diagnostics.Metrics;

namespace Booking_web_Search.HelperFunctions
{
    public class BookingSearch : BasePageObject
    {


        public BookingSearch(IWebDriver driver) : base(driver)
        {


            VerifyPageLoaded(By.Id("b2indexPage"));
        }

        public static BookingSearch GoToPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.booking.com/");
            return new BookingSearch(driver);
        }

        public static BookingSearch ClickSearchButton(IWebDriver driver)
        {

            driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[4]")).Click();

            return new BookingSearch(driver);


        }

        public static BookingSearch waittoload(string xpath, IWebDriver driver)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 8));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
          
            return new BookingSearch(driver);
        }





        public static BookingSearch GuestsList(IWebDriver driver)
        {
            driver.FindElement(By.ClassName("xp__input")).Click(); // 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
           
            
            driver.FindElement(By.XPath("//*[@id=\"xp__guests__inputs-container\"]/div/div/div[2]/div/div[2]/button[2]/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//*[@id=\"xp__guests__inputs-container\"]/div/div/div[3]/select")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//*[@id=\"xp__guests__inputs-container\"]/div/div/div[3]/select/option[9]")).Click();

            return new BookingSearch(driver);


        }



        public static BookingSearch Gotoresultspage(IWebDriver driver)
        {
            return new BookingSearch(driver);
        }


        public static BookingSearch VerifyResults(IWebDriver driver)
        {

            var destination = driver.FindElement(By.ClassName("ce45093752")).GetAttribute("value");

            driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[3]/div[2]/button")).Click();

            //driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[3]/div[2]/div[1]/button[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var datestart = driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[3]/div[2]/div/div/div[1]/div[1]/table/tbody/tr[4]/td[5]/span")).GetAttribute("data-date");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var dateend = driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[3]/div[2]/div/div/div[1]/div[1]/table/tbody/tr[4]/td[7]/span")).GetAttribute("data-date");


            driver.FindElement(By.ClassName("fca8fcd83b")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[4]/div/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var adults = driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[4]/div/div/div/div/div[1]/div[2]/span")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var childern = driver.FindElement(By.XPath("//*[@id='left_col_wrapper']/div[1]/div/div/form/div/div[4]/div/div/div/div/div[2]/div[2]/span")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var age = driver.FindElement(By.XPath("//*[@class='bebf0b2b63']/option[9]")).GetAttribute("value");

            driver.FindElement(By.ClassName("fca8fcd83b")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            if (destination == "London" && datestart == "2023-02-24" && dateend == "2023-02-26" && adults == "2" && childern == "1" && age == "7")
            {

                Console.WriteLine("Results are Verified and in Match with our search criteria");


            }

            else

            {

                Console.WriteLine("Results are Not in Match with results criteria");
            }


            return new BookingSearch(driver);
        }



        public static BookingSearch StarRating(IWebDriver driver)
        {
            return new BookingSearch(driver);
        }

        public static BookingSearch TotalResultsCheck(IWebDriver driver)
        {
            var total = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[3]/div/div/span")).Text;
            int x = Int32.Parse(total);
            int y = 0;
            int j = 5; //Counter for selection reduction

            if (x >= 100 && x <= 300)
            {
                Console.WriteLine("Total Results are within range no need to click more options");

            }

            else if (x < 300)
            {
                Console.WriteLine("Total Results  are Not in the within range and above 300. Reduce the selection ");
                for (int i = 4; i > j;)
                {
                    IWebElement element = driver.FindElement(By.Id("filter_group_popular_activities_:R24q:"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);                    //*[@id="filter_group_popular_activities_:R24q:"]/div[4]/label/span[2]
                    Console.WriteLine("Reducing Selection ");
                    driver.FindElement(By.XPath("//*[@id='filter_group_popular_activities_:R24q:']div[i]/label/span[2]")).Click();
                    total  = driver.FindElement(By.XPath("//*[@id='filter_group_popular_activities_:R24q:']/div[i]/label/span[3]/div/div/span")).Text;
                    int z = Int32.Parse(total);

                    if (z < 300)
                    {
                        break;
                    }

                    else 
                    
                    {
                        Console.WriteLine("Reducing Selection ");
                        j = j + 2;
                    }
                    
                    i = i + 2; 
                }
                
                                
            }

            else 
            
            {
               

                for (int i = 3; i > j;)
                {
                    IWebElement element = driver.FindElement(By.Id("filter_group_class_:R1kq:"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);                    //*[@id="filter_group_popular_activities_:R24q:"]/div[4]/label/span[2]
                    Console.WriteLine("Increasing Selection ");
                    
                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1kq:']/div[i]/label/span[2]")).Click();
                    total = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1kq:']/div[3]/label/span[i]/div/div/span")).Text;
                    int z = Int32.Parse(total);

                    if (z <100 )
                    {
                        break;
                    }

                    else

                    {
                        Console.WriteLine("Increasing Selection ");
                        j = j + 2;
                    }

                    i = i + 2;
                }
               
                Console.WriteLine("Total Results are Not in the within range and not above 100. Increase the Selection");

               
            
            }
                return new BookingSearch(driver);
        }
       
          
        
        public static BookingSearch ResultsCountCheck(string totalno1, IWebDriver driver)
        {

            IWebElement element = driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div/div[4]/div[2]/nav/div/div[3]/button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);

            int count = 0; // initializing the count
            while (driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div/div[4]/div[2]/nav/div/div[3]/button")).Enabled)
            {
                int rowscount =  driver.FindElements(By.XPath("//*[@data-testid='property-card']")).Count;
                    
                    count += rowscount;
                    
                    driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div/div[4]/div[2]/nav/div/div[3]/button")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             
            }
            int rowscount1 = driver.FindElements(By.XPath("//*[@data-testid='property-card']")).Count;
            count = rowscount1 + count;


            if (Int32.Parse(totalno1) == count)
            {
                Console.WriteLine("Values Match");
                return new BookingSearch(driver);
            }
            else

            {
                
                Console.WriteLine("Values dont match");
                return new BookingSearch(driver);

            }
        }

    }

}
