using MiaplazaHomeAss.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MiaplazaHomeAss.tests
{
    public class Tests : BaseTest
    {
        

        [Test]
        public void verifyStudentInfoPage()
        {
            
            onlineSchoolPage = homePage.clickOnCourseLink();

            mOHOPage = onlineSchoolPage.clickOnMOHSLink();

            formPage = mOHOPage.clickOnMOHSInitialApplicationLink();

            formPage.clickOnNextButtonToParentsInfo();
            formPage.fillParentsInfo(testData.FirstName, testData.LastName, testData.Email,testData.CountryCode, testData.PhoneNumber,testData.GardianInfo, testData.PrefferedStartDate);
            
            formPage.clickOnNextButtonToStudentInfo();

            //Assert
            Assert.IsTrue(formPage.isStudentInfoPageHeadingVisible());

        }


    }
}