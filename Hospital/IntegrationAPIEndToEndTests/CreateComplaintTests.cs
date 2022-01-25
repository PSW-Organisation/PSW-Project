using IntegrationAPIEndToEndTests.Pages;
using IntegrationAPISeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAPIEndToEndTests
{
    public class CreateComplaintTests : IDisposable
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;
        private ManagerHomePage managerHomePage;
        private ComplaintsPage complaintsPage;
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        public CreateComplaintTests()
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
            managerHomePage.ComplaintsButtonClick();
            complaintsPage = new ComplaintsPage(driver);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [SkippableFact]
        public void CreateComplaint()
        {
            Skip.If(skippable);
            int complaintsCount = complaintsPage.ComplaintsCount();
            complaintsPage.AddButtonClick();
            complaintsPage.SelectPharmacy("Flos");
            complaintsPage.InsertTitle("Pun mi vas je");
            complaintsPage.InsertContent("Dobro ste procitali, pun mi vas je.");
            complaintsPage.SubmitForm();
            complaintsPage.WaitUntilSubmit();

            Assert.Equal(complaintsCount + 1, complaintsPage.ComplaintsCount());

            Assert.Equal("Pun mi vas je", complaintsPage.GetLastRowTitle());
            Assert.Equal("Dobro ste procitali, pun mi vas je.", complaintsPage.GetLastRowContent());
        }

        [SkippableFact]
        public void TestInvalidTitle()
        {
            Skip.If(skippable);
            complaintsPage.AddButtonClick();
            complaintsPage.SelectPharmacy("Flos");
            complaintsPage.InsertContent("Dobro ste procitali, pun mi vas je.");
            complaintsPage.SubmitForm();
            complaintsPage.WaitForAlertDialog();
            Assert.Equal(complaintsPage.GetDialogMessage(), ComplaintsPage.InvalidTitleMessage);
            complaintsPage.ResolveAlertDialog();
        }

        [SkippableFact]
        public void TestInvalidContent()
        {
            Skip.If(skippable);
            complaintsPage.AddButtonClick();
            complaintsPage.SelectPharmacy("Flos");
            complaintsPage.InsertTitle("Pun mi vas je");
            complaintsPage.SubmitForm();
            complaintsPage.WaitForAlertDialog();
            Assert.Equal(complaintsPage.GetDialogMessage(), ComplaintsPage.InvalidContentMessage);
            complaintsPage.ResolveAlertDialog();
        }

        [SkippableFact]
        public void TestInvalidPharmacy()
        {
            Skip.If(skippable);
            complaintsPage.AddButtonClick();
            complaintsPage.InsertTitle("Pun mi vas je");
            complaintsPage.InsertContent("Dobro ste procitali, pun mi vas je.");
            complaintsPage.SubmitForm();
            complaintsPage.WaitForAlertDialog();
            Assert.Equal(complaintsPage.GetDialogMessage(), ComplaintsPage.InvalidPharmacyMessage);
            complaintsPage.ResolveAlertDialog();
        }
    }
}
