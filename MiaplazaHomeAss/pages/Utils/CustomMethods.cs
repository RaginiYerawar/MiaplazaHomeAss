using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages.Utils
{
    public static class CustomMethods
    {

        public static void Click(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropDownByvalue(this IWebElement locator, string value)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }


    }
}
