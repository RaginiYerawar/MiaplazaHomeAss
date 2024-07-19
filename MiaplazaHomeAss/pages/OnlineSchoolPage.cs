using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages
{
    public class OnlineSchoolPage
    {
        private readonly IWebDriver driver;

        //constructor
        public OnlineSchoolPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        //locators=>page objects
        IWebElement MOHSLink => driver.FindElement(By.XPath("//li[@id='menu-item-4218']/*[contains(text(), 'ASU at MOHS')]"));

        //actions
        public MOHSPage clickOnMOHSLink()
        {
            MOHSLink.Click();
            return new MOHSPage(driver);
        }
    }
}
