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

       
        public IWebElement searchbutton => driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[4]"));
      
        public IWebElement Guestbutton => driver.FindElement(By.ClassName("xp__input"));
        public IWebElement Child => driver.FindElement(By.XPath("//*[@id='xp__guests__inputs-container']/div/div/div[2]/div/div[2]/button[2]/span"));
        public IWebElement childdropdown => driver.FindElement(By.XPath("//*[@id='xp__guests__inputs-container']/div/div/div[3]/select"));
        public IWebElement childage => driver.FindElement(By.XPath("//*[@id='xp__guests__inputs-container']/div/div/div[3]/select/option[9]"));
        public IWebElement Cookies=> driver.FindElement(By.XPath("//*[@id='onetrust-accept-btn-handler']"));
         public IWebElement Dest=>driver.FindElement(By.Name("ss"));
        public IWebElement Datebutton => driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[1]/div[2]/div/div/div/div/span"));
       
        public IWebElement Startdate => driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table/tbody/tr[4]/td[5]"));
      
        public IWebElement Enddate => driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table/tbody/tr[4]/td[7]"));

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
            childdropdown.Click();  
            childage.Click();



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
