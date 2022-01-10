using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalEndToEndTests
{
    public class CreateFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;

        private Pages.LoginPage loginPage;
        private Pages.ProfilePage profilePage;
        private Pages.CreateFeedbackPage createFeedbackPage;

        public CreateFeedbackTests()
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

            loginPage = new Pages.LoginPage(driver);
            loginPage.Navigate(loginPage.PatientLoginURI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.TypeUsername("kristina");
            loginPage.TypePassword("kristinica");
            loginPage.ClickSubmitButton();
            loginPage.WaitUntilProfileRedirect();

            profilePage = new Pages.ProfilePage(driver);
            Assert.Equal(driver.Url, profilePage.ProfilePageURI);
            profilePage.ClickFeedbackLink();
            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.WaitUntilTextAreaDisplayed();
        }

        [Fact]
        public void CreateValidFeedback()
        {
            createFeedbackPage.TypeTextArea("Test321");
            createFeedbackPage.ClickRadioAnonymous();
            createFeedbackPage.ClickRadioPublish();
            createFeedbackPage.ClickSubmitButton();

            createFeedbackPage.WaitUntilToastrSuccess();
            Assert.True(!createFeedbackPage.TextAreaElementDisplayed());
        }

        [Fact]
        public void FeedbackSubmitDisabled()
        {
            createFeedbackPage.TypeTextArea(" ");
            createFeedbackPage.ClickRadioAnonymous();
            createFeedbackPage.ClickRadioPublish();

            Assert.True(createFeedbackPage.DisabledButtonDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
