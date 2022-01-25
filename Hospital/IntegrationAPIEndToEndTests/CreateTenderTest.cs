using IntegrationAPIEndToEndTests.Pages;
using IntegrationAPISeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace IntegrationAPIEndToEndTests
{
    public class CreateTenderTest : IDisposable
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;
        private ManagerHomePage managerHomePage;
        private TenderPage tenderPage;
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        public CreateTenderTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);
            loginPage = new LoginPage(driver);
            loginPage.Navigate(loginPage.ManagerLoginURI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.TypeUsername("jagodica");
            loginPage.TypePassword("Jagodica123!");
            loginPage.ClickSubmitButton();
            loginPage.WaitUntilHomeRedirect();

            managerHomePage = new ManagerHomePage(driver);
            Assert.Equal(driver.Url, managerHomePage.ManagerHomepageURI);
            managerHomePage.TenderButtonClick();
            tenderPage = new TenderPage(driver);
        }

        [SkippableFact]
        public void CreateTender()
        {
            Skip.If(skippable);

            Thread.Sleep(4000);

            tenderPage.ButtonAddClick();
            int tenderCount = tenderPage.GetCardCount();

            tenderPage.InsertAmmount("30");
            tenderPage.InsertName("pomorandza");
            tenderPage.TenderItemAddButtonClick();
            //tenderPage.SelectDate();

            tenderPage.PostButtonClick();
            tenderPage.WaitUntilSubmit();
            Thread.Sleep(4000);

            int newCount = tenderPage.GetCardCount();
            Assert.Equal(tenderCount + 1, newCount);
            Assert.True(tenderPage.CheckNameExist("Tender 7"));
            Assert.True(tenderPage.CheckItemExist("pomorandza 30"));
            //Assert.True(tenderPage.CheckDateExist("indefinite"));
        }

        [SkippableFact]
        public void InvalidTender()
        {
            Skip.If(skippable);

            Thread.Sleep(4000);

            tenderPage.ButtonAddClick();
            int tenderCount = tenderPage.GetCardCount();

            tenderPage.InsertAmmount("30");
            tenderPage.InsertName("pomorandza");
            tenderPage.TenderItemAddButtonClick();
            //tenderPage.SelectDate();

            tenderPage.PostButtonClick();
            tenderPage.WaitUntilSubmit();
            Thread.Sleep(4000);

            int newCount = tenderPage.GetCardCount();
            Assert.Equal(tenderCount + 1, newCount);
            Assert.True(tenderPage.CheckNameExist("tenderBanana"));
            Assert.True(tenderPage.CheckItemExist("Kvazimodo"));
            //Assert.True(tenderPage.CheckDateExist("indefinite"));
        }
    }
}
