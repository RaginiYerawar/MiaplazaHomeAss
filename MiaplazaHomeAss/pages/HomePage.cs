using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        //constructor
        public HomePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        //locators=>page objects
        IWebElement CourseLink => driver.FindElement(By.XPath("//a[contains(@href, 'miaprep.com/online-school')]"));

        //actions
        public OnlineSchoolPage clickOnCourseLink() {
            CourseLink.Click();
            return new OnlineSchoolPage(driver);
        }


    }
}
