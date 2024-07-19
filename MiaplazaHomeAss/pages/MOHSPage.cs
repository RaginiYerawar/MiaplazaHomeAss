using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages
{
    public class MOHSPage
    {
        private readonly IWebDriver driver;

        //constructor
        public MOHSPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locators=>page objects
        IWebElement MOHSInitialApplicationLink => driver.FindElement(By.XPath("//*[contains(@class,'block-button')]/a[contains(@href, '/form/MOHSInitialApplication/')]"));

        //actions
        public FormPage clickOnMOHSInitialApplicationLink()
        {
            MOHSInitialApplicationLink.Click();
            return new FormPage(driver);
        }

    }
}
