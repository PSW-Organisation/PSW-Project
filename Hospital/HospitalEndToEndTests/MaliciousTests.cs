using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalEndToEndTests
{
    public class MaliciousTests : IDisposable
    {
        private readonly IWebDriver driver;

        private Pages.LoginPage loginPage;
        private Pages.ManagerHomePage managerHomePage;
        private Pages.MaliciousPage maliciousPage;

        public MaliciousTests()
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
            loginPage.Navigate(loginPage.ManagerLoginURI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.TypeUsername("jagodica");
            loginPage.TypePassword("Jagodica123!");
            loginPage.ClickSubmitButton();
            loginPage.WaitUntilHomeRedirect();

            managerHomePage = new Pages.ManagerHomePage(driver);
            Assert.Equal(driver.Url, managerHomePage.ManagerHomepageURI);
            Assert.True(managerHomePage.MaliciousCardDisplayed());

            managerHomePage.ClickMaliciousCard();
            managerHomePage.WaitUntilMaliciousRedirect();
            maliciousPage = new Pages.MaliciousPage(driver);
            Assert.Equal(driver.Url, maliciousPage.MaliciousPageURI);
            maliciousPage.EnsureRowsAreDisplayed();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestValidBlock()
        {
            maliciousPage.ClickBlockMalicious();
            maliciousPage.WaitUntilToastrSuccess();
            Assert.True(maliciousPage.DisabledButtonDisplayed());
        }
    }
}
