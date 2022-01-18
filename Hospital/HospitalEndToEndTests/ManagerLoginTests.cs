using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalEndToEndTests
{
    public class ManagerLoginTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;

        public ManagerLoginTests()
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
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestValidManagerLoginCredentials()
        {
            loginPage.Navigate(loginPage.ManagerLoginURI);
            loginPage.TypeUsername("jagodica");
            loginPage.TypePassword("Jagodica123!");
            loginPage.ClickSubmitButton();

            loginPage.WaitUntilHomeRedirect();
            Assert.Equal("http://localhost:4200/home", driver.Url);
        }

        [Fact]
        public void TestInvalidManagerLoginCredentials()
        {
            loginPage.Navigate(loginPage.ManagerLoginURI);
            loginPage.TypeUsername("wrongUsername");
            loginPage.TypePassword("password");
            loginPage.ClickSubmitButton();

            loginPage.WaitUntilToastrError();
            Assert.Equal("http://localhost:4200/", driver.Url);
        }
    }
}
