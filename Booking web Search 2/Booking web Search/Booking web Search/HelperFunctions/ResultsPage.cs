using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_web_Search.HelperFunctions
{
    public class ResultsPage
    {

        IWebDriver driver;
        [FindsBy(How = How.Name, Using = "ss")]
        private IWebElement dest;
        [FindsBy(How = How.XPath, Using = "//*[@class='fca8fcd83b']/div[2]/button/span[2]")]
        private IWebElement datefilter;
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[3]/span")]
        private IWebElement startdate;
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[5]/span")]
        private IWebElement enddate;
        [FindsBy(How = How.XPath, Using = "//form/div/div[4]/div/button")]
        private IWebElement peoplebutton;
        [FindsBy(How = How.ClassName, Using = "fca8fcd83b")]
        private IWebElement PageClick;
        [FindsBy(How = How.XPath, Using = "//*[@data-testid='occupancy-popup']/div/div[1]/div[2]/span")]
        private IWebElement adults;
        [FindsBy(How = How.XPath, Using = "//*[@data-testid='occupancy-popup']/div/div[2]/div[2]/span")]
        private IWebElement kids;
        [FindsBy(How = How.XPath, Using = "//*[@data-testid='occupancy-popup']/div/div[3]/div/div/select/option[9]")]
        private IWebElement ages;

        [FindsBy(How = How.XPath, Using = "//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[3]/div/div/span")]
        private IWebElement total;

        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void VerifyResults()
        {

            var destination = dest.GetAttribute("value");

            datefilter.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var datestart = startdate.GetAttribute("data-date");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var dateend = enddate.GetAttribute("data-date");


            PageClick.Click();    
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            peoplebutton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var adult = adults.Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var childrn = kids.Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var age = ages.Text;

            driver.FindElement(By.ClassName("fca8fcd83b")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            if (destination == "London" && datestart == "2023-03-01" && dateend == "2023-03-03" && adult == "2" && childrn == "1" && age == "7 years old")
            {

                Console.WriteLine("Results are Verified and in Match with our search criteria");

            }

            else

            {

                Console.WriteLine("Results are Not in Match with results criteria");
            }


        }

        public void TotalResultsCheck()
        {
            var totals = total.Text;
            int x = Int32.Parse(totals);
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
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);                  
                    Console.WriteLine("Reducing Selection ");
                    driver.FindElement(By.XPath("//*[@id='filter_group_popular_activities_:R24q:']div[i]/label/span[2]")).Click();
                    totals = total.Text;
                    int z = Int32.Parse(totals);

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
                    totals = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1kq:']/div[3]/label/span[i]/div/div/span")).Text;
                    int z = Int32.Parse(totals);

                    if (z < 100)
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
            
        }

        public void waittoload(string xpath)
        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 8));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        }

        public void ResultsCountCheck(string totalno1)
        {

            IWebElement element = driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div[4]/div[2]/nav/div/div[3]/button"));  //*[@id="search_results_table"]/div[2]/div/div/div[4]/div[2]/nav/div/div[3]/button
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);

            int count = 0; // initializing the count
            while (driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div[4]/div[2]/nav/div/div[3]/button")).Enabled)
            {
                int rowscount = driver.FindElements(By.XPath("//*[@data-testid='property-card']")).Count;

                count += rowscount;

                driver.FindElement(By.XPath("//*[@id='search_results_table']/div[2]/div/div/div[4]/div[2]/nav/div/div[3]/button")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            }
            int rowscount1 = driver.FindElements(By.XPath("//*[@data-testid='property-card']")).Count;
            count = rowscount1 + count;


            if (Int32.Parse(totalno1) == count)
            {
                Console.WriteLine("Values Match");
            }
            else

            {

                Console.WriteLine("Values dont match");
                

            }
        }
    }
}
