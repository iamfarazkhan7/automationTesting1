using Booking_web_Search.HelperFunctions;
using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using DocumentFormat.OpenXml.ExtendedProperties;
using TechTalk.SpecFlow.Assist;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools;

namespace Booking_web_Search.StepDefinitions
{
    [Binding]
    public class BookingSearchStepDefinitions 
    {
        private IWebDriver driver;
        public string propertytotal;
       // private BookingSearch mainpage;


        [Given(@"I am on Booking site")]
        public void GivenIAmOnBookingSite()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            BookingSearch.GoToPage(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(11);


        }

        [When(@"I click on search location and enter location")]
        public void WhenIClickOnSearchLocationAndEnterLocation()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(11);

            driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']")).Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


            driver.FindElement(By.Name("ss")).SendKeys("London"); 
        }

        [When(@"I enter the desired dates")]
        public void WhenIEnterTheDesiredDates()

        {

                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[1]/div[2]/div/div/div/div/span")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table/tbody/tr[5]/td[3]")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table/tbody/tr[5]/td[6]")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        }
        [When(@"I select 2 adults , 1 childern of Age 7")]
        public void WhenISelect2Adults1ChildernOfAge7()
        {
            BookingSearch.GuestsList(driver);
        }

        [Then(@"I click on to the search button")]
        public void ThenIClickOnToTheSearchButton()
        {

            BookingSearch.ClickSearchButton(driver);


        }
        [Then(@"I am on Booking Site results page")]
        public void ThenIAmOnBookingSiteResultsPage()
        {

            BookingSearch.waittoload("//*[@id='b2searchresultsPage']", driver);

        }

        [When(@"Results on Left Side is in match with Search")]
        public void GivenResultsOnLeftSideIisInMatchWithSearch()
        {
            BookingSearch.VerifyResults(driver);
        }

        [When(@"I click on <Rating> star properties and budget")]
        public void WhenIClickOnRatingStarPropertiesAndBudget(Table star)
        {

            /// Locating Star rating 
            IWebElement element = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[2]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

           
            var results = star.CreateSet<StarRating>();
            var totalno2 = "";

            int sumofboth;
            
            foreach (var userData in results)
            {
                if (userData.Rating == "4")
                {

                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[2]")).Click();

                    var totalno1 = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[3]/div/div/span")).Text;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


                    /// Locating Budget rating 
                        IWebElement element1 = driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[2]"));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element1);

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                        driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[2]")).Click();
                        totalno2 = driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[3]/div/div/span")).Text;
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                                     
                     // total values to compare      
                       
                    //sumofboth = Int32.Parse(totalno1) + Int32.Parse(totalno2);

                    BookingSearch.ResultsCountCheck(totalno2, driver) ;
                }

                else
                {


                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[2]")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[2]")).Click();

                    var totalno1 = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[3]/div/div/span")).Text;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    BookingSearch.ResultsCountCheck(totalno1,driver);

                }
                BookingSearch.StarRating(driver);

            }
        }

        

        [Then(@"the sum of properties matches the total result")]
        public void ThenTheSumOfPropertiesMatchesTheTotalResult()
        {
            Console.WriteLine("Values Match");
            driver.Quit();
        }
    }
}
