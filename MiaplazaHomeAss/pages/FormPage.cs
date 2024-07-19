using MiaplazaHomeAss.pages.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages
{
    public class FormPage
    {
        private readonly IWebDriver driver;

        //constructor
        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locators=>page objects
        IWebElement NextButtonToParentsInfo => driver.FindElement(By.XPath("//button[@aria-label='Next\nNavigates to page 2 out of 4' and contains(@class, 'next_previous') and @type='button' and @elname='next']"));
        IWebElement FirstName => driver.FindElement(By.XPath("//*[@name='Name' and @elname='First']"));
        IWebElement LastName => driver.FindElement(By.XPath("//*[@name='Name' and @elname='Last']"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("//*[contains(@id, 'Email-arialabel')]"));
        IWebElement CountryCodeDropdown => driver.FindElement(By.XPath("//*[contains(@class, 'flag-container')]"));
        IWebElement PhoneNumber => driver.FindElement(By.XPath("//*[@name='PhoneNumber' and @id='PhoneNumber']"));
        IWebElement GardianInfoDropdown => driver.FindElement(By.XPath("//*[contains(@id, 'select2-Dropdown-arialabel-container')]"));
        IWebElement DateLocator => driver.FindElement(By.XPath("//*[@id='Date-date']"));
        IWebElement CalenderLocator => driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']"));
        IWebElement MonthSelector => driver.FindElement(By.XPath("//*[contains(@class, 'datepicker-month')]"));
        IWebElement YearSelector => driver.FindElement(By.XPath("//*[contains(@class, 'datepicker-year')]"));
        IWebElement NextButtonToStudentInfo => driver.FindElement(By.XPath("//button[@aria-label='Next\nNavigates to page 3 out of 4' and contains(@class, 'next_previous') and @type='button' and @elname='next']"));
        IWebElement StudentInfoPageHeading => driver.FindElement(By.XPath("//b[text()='Student Information']"));

        //locating element with a dynamically constructed XPath
        public IWebElement GetDaySelector(string day)
        {
            string xPath = $"//a[text()='{day}']";
            return driver.FindElement(By.XPath(xPath));
        }

        public IWebElement GetGardianInfoDropdownOption(string option)
        {
            string xPath = $"//li[text()='{option}']";
            return driver.FindElement(By.XPath(xPath));
        }

        public IWebElement GetCountryCodeOption(string countryCode)
        {
            string xPath = $"//*[contains(text(), '{countryCode}')]";
            return driver.FindElement(By.XPath(xPath));
        }

        //actions
        public void clickOnNextButtonToParentsInfo()
        {
            NextButtonToParentsInfo.Click();
            
        }

        public void clickOnNextButtonToStudentInfo()
        {
            NextButtonToStudentInfo.Click();

        }

        public void fillParentsInfo(string firstname, string lastname, string email,string countryCode, string phoneNumber,string gardianInfo, string date)
        {
            FirstName.EnterText(firstname);
            LastName.EnterText(lastname);
            EmailAddress.EnterText(email);
            CountryCodeDropdown.Click();
            GetCountryCodeOption(countryCode).Click();
            PhoneNumber.EnterText(phoneNumber);
            GardianInfoDropdown.Click();
            GetGardianInfoDropdownOption(gardianInfo).Click();
            selectDate(date);
            Thread.Sleep(6000);
        }

        public void selectDate(string date)
        {
            string[] dates = date.Split('.');
            string day = dates[0];
            string month = dates[1];
            string year = dates[2];

            DateLocator.Click();
            
            MonthSelector.SelectDropDownByvalue(month);
            YearSelector.SelectDropDownByvalue(year);

            GetDaySelector(day).Click();
        }

        public Boolean isStudentInfoPageHeadingVisible()
        {
            return StudentInfoPageHeading.Displayed;
        }
    }
}
