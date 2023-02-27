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
using DocumentFormat.OpenXml.Spreadsheet;


namespace Booking_web_Search.HelperFunctions
{
    public class BookingSearch 

    {

        IWebDriver driver;

        //*[@id="xp__guests__toggle"]
        public IWebElement searchbutton => driver.FindElement(By.CssSelector("button[type='submit']")); 
        public IWebElement Guestbutton => driver.FindElement(By.XPath("//*[@class='d67edddcf0']/button[1]"));
        public IWebElement Child => driver.FindElement(By.XPath("//*[@data-testid='occupancy-popup']/div/div[2]/div[2]/button[2]"));
        public IWebElement childdropdown => driver.FindElement(By.Name("age"));
        public IWebElement childage => driver.FindElement(By.ClassName("sb_child_ages_empty_zero"));
        public IWebElement Cookies=> driver.FindElement(By.XPath("//*[@id='onetrust-accept-btn-handler']"));
         public IWebElement Dest=>driver.FindElement(By.Name("ss"));
        public IWebElement Datebutton => driver.FindElement(By.XPath("//*[@data-testid='date-display-field-start']"));
        public IWebElement Startdate => driver.FindElement(By.XPath("//*[@data-testid='searchbox-datepicker-calendar']/div[1]/div[2]/table/tbody/tr[1]/td[3]"));
        public IWebElement Enddate => driver.FindElement(By.XPath("//*[@data-testid='searchbox-datepicker-calendar']/div[1]/div[2]/table/tbody/tr[1]/td[5]"));

        public BookingSearch(IWebDriver driver) 
        {
            this.driver = driver;
        }
       
       
        public void  GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.booking.com/");
      
        }


        public void AcceptCookies()
        {

            Cookies.Click();
          }

        public void Destination(string loc)
        {

            Dest.SendKeys(loc);
         
        }

        public  void desireddates()
        {

            Datebutton.Click();
            Startdate.Click();
            Enddate.Click();
        }


        public void GuestsList()
        {
            Guestbutton.Click();
            Child.Click();

            SelectElement dropDown = new SelectElement(childdropdown);
            dropDown.SelectByValue("7");
                           
            
         }

        public  void ClickSearchButton()
        {
            searchbutton.Click();


        }

        public void waittoload(string xpath)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 8));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
          
        }





    }

}
