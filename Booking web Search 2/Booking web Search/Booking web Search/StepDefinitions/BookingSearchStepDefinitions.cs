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
using Booking_web_Search.Extensions;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.Linq.Expressions;

namespace Booking_web_Search.StepDefinitions
{
    [Binding]
    public class BookingSearchStepDefinitions 
    {

        
        [Given(@"I am on Booking site")]
        public void GivenIAmOnBookingSite()
        {
            try
            {
                BasePageObject.StartTest("https://www.booking.com/");
                BookingSearch bs = new BookingSearch(BasePageObject.driver);

                

            }

            catch (Exception e)
            {
                Console.WriteLine("Test Failed: Could load load the page" +e.Message);
                BasePageObject.CloseTest();
                throw; 
            
            }
            


        }

        [When(@"I enter destination (.*)")]
        public void WhenIEnterDestination(string loc)
        {

            try
            {
                BookingSearch bs = new BookingSearch(BasePageObject.driver);

                //WebElementExtensions.WaitForElementIsDisplayed(driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']")), 1000);
                bs.AcceptCookies();
                bs.Destination("London");
            }

            catch (Exception e) {

                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;
            }
        }

        [When(@"I enter the desired dates")]
        public void WhenIEnterTheDesiredDates()

        {

            try
            {
                BookingSearch bs = new BookingSearch(BasePageObject.driver);
                bs.desireddates();
            }

            catch (Exception e)

            {
                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;

            }

        }
        [When(@"I select 2 adults , 1 childern of Age 7")]
        public void WhenISelect2Adults1ChildernOfAge7()
        {

            try
            {
                BookingSearch bs = new BookingSearch(BasePageObject.driver);
                bs.GuestsList();
            }

            catch (Exception e) 
            
            {

                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;
            }
        }

        [Then(@"I click on to the search button")]
        public void ThenIClickOnToTheSearchButton()
        {

            try
            {
                BookingSearch bs = new BookingSearch(BasePageObject.driver);
                bs.ClickSearchButton();
            }

            catch (Exception e )
            
            {
                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;
            }
        }

        
        [Then(@"I am on Booking Site results page")]
        public void ThenIAmOnBookingSiteResultsPage()

        {
        try
        {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.waittoload("//*[@id='b2searchresultsPage']");
        }

        catch(Exception e) 
        
        {
            Console.WriteLine("Test Failed: Could load load the page" + e.Message);
            BasePageObject.CloseTest();
            throw;


        }
        }

        [When(@"Results on Left Side is in match with Search")]
        public void GivenResultsOnLeftSideIisInMatchWithSearch()
        {
            try
            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.VerifyResults();
            }
            catch (Exception e )
            {
                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;
            }
        }

        [When(@"I click on 5 Star Rating")]
        public void WhenIClickOn5StarRating()
        {
            try
            {

                ResultsPage rp = new ResultsPage(BasePageObject.driver);

                /// Locating 5  Star rating 
                IWebElement element = BasePageObject.driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[2]"));
                ((IJavaScriptExecutor)BasePageObject.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                BasePageObject.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


                BasePageObject.driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[2]")).Click();

                var totalno1 = BasePageObject.driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[3]/div/div/span")).Text;
                BasePageObject.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                rp.ResultsCountCheck(totalno1);
            }

            catch (Exception e )
            {
                Console.WriteLine("Test Failed: Could load load the page" + e.Message);
                BasePageObject.CloseTest();
                throw;

            }

            //var results = star.CreateSet<StarRating>();
                                   
            
            /*foreach (var userData in results) // for more then one star rating 
            {
                if (userData.Rating == "4")
                {

                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[2]")).Click();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


                    /// Locating Budget rating 
                        IWebElement element1 = driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[2]"));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element1);

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[2]")).Click();
                        var totalno1 = driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[3]/div/div/span")).Text;
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                    BookingSearch.ResultsCountCheck(totalno1, driver) ;
                }

                else
                {

                    driver.FindElement(By.XPath("//*[@id='filter_group_pri_:Rcq:']/div[2]/div[5]/label/span[2]")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[7]/label/span[2]")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[2]")).Click();

                    var totalno1 = driver.FindElement(By.XPath("//*[@id='filter_group_class_:R1cq:']/div[9]/label/span[3]/div/div/span")).Text;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                    BookingSearch.ResultsCountCheck(totalno1,driver);

                }
                BookingSearch.StarRating(driver);

            }*/
        }

        [When(@"I change the language to Arabic")]
        public void WhenIChangeTheLanguageToArabic()
        {
            try
            { 

                WebElementExtensions.WaitForElementIsDisplayed(BasePageObject.driver.FindElement(By.ClassName("cb5ebe3ffb")));
                BasePageObject.driver.FindElement(By.ClassName("cb5ebe3ffb")).Click();

                WebElementExtensions.WaitForElementIsDisplayed(BasePageObject.driver.FindElement(By.ClassName("cf67405157")));
                BasePageObject.driver.FindElement(By.ClassName("cf67405157")).Click();

            }

            catch (Exception e) { Console.WriteLine(e.Message); }   


        }
        [When(@"I wait for the page to load")]
        public void WhenIWaitForThePageToLoad()
        {
            try
            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.waittoload("//*[@id='b2searchresultsPage']");
            }

            catch (Exception e) { Console.WriteLine(e.Message); }
                    
                    
                    

            
        
        }
        [When(@"I verify that total results are above 100 and below 300")]
        public void WhenIVerifyThatTotalResultsAreAbove100AndBelow300()
        {
            try
            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.TotalResultsCheck();
            }

            catch(Exception e) { Console.WriteLine(e.Message); }

        }

        [When(@"I add more selection if results are below 100")]
        public void WhenIAddMoreSelectionIfResultsAreBelow100()
        {
            try
            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.TotalResultsCheck();
            }

            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        [When(@"I reduce selection if results are above 300")]
        public void WhenIReduceSelectionIfResultsAreAbove300()
        {
            try
            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                rp.TotalResultsCheck();
            }

            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        [Then(@"the sum of properties matches the total result")]
        public void ThenTheSumOfPropertiesMatchesTheTotalResult()
        {


            try

            {
                ResultsPage rp = new ResultsPage(BasePageObject.driver);
                string v = BasePageObject.driver.FindElement(By.TagName("h1")).GetAttribute("aria-label");
                var pos = v.IndexOf(":");
                var subText = v.Substring(pos + 1);
                var pos2 = subText.IndexOf(" ");
                var subText2 = v.Substring(1, pos2 - 1);
                Console.Write("Total no of properties :" + subText2);
                rp.ResultsCountCheck(subText2);
            }
            catch (Exception e ){
                Console.WriteLine(e.Message);
                BasePageObject.CloseTest();
            }
            
           
            
        }
           
            
        
    }
}
