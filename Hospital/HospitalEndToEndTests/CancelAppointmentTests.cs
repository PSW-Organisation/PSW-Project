using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalEndToEndTests
{
    public class CancelAppointmentTests : IDisposable
    {
        private readonly IWebDriver driver;

        private Pages.LoginPage loginPage;
        private Pages.ProfilePage profilePage;
        private Pages.AppointmentsPage appointmentsPage;

        public CancelAppointmentTests()
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
            profilePage.ClickAppointmentsLink();
            profilePage.WaitUntilAppointmentsRedirect();
            
            appointmentsPage = new Pages.AppointmentsPage(driver);
            Assert.Equal(driver.Url, appointmentsPage.AppointmentsPageURI);
            appointmentsPage.EnsureRowsAreDisplayed();

        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestValidCancelAppointment()
        {
            appointmentsPage.ClickCancelAppointment();
            appointmentsPage.WaitUntilToastrSuccess();
            Assert.True(appointmentsPage.DisabledButtonDisplayed());
        }
    }
}

