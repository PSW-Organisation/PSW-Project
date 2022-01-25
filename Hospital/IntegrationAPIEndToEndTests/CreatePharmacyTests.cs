using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace IntegrationAPISeleniumTests
{
    public class CreatePharmacyTests : IDisposable
    {
        private readonly IWebDriver driver;

        private Pages.LoginPage loginPage;
        private Pages.ManagerHomePage managerHomePage;
        private Pages.CreatePharmacyPage createPharmacy;
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        public CreatePharmacyTests()
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
            managerHomePage.PharmaciesCardDisplayed();
         
            createPharmacy = new Pages.CreatePharmacyPage(driver);
            createPharmacy.WaitUntilModalAppears();
        }

        [SkippableFact]
        public void CreatePharmacy()
        {
            Skip.If(skippable);
            int pharmaciesCount = createPharmacy.PharmaciesCount();
            createPharmacy.AddButtonClick();
            createPharmacy.WaitUntilModalAppears();
            createPharmacy.InsertName("Jankovic");
            createPharmacy.InsertAddress("Vojvode Misica");
            createPharmacy.InsertUrl("wwww.jankovic.com");
            createPharmacy.SubmitForm();
            createPharmacy.WaitUntilSubmit();
            Thread.Sleep(2000);
            Assert.Equal(pharmaciesCount + 1, createPharmacy.PharmaciesCount());

            Assert.Equal("Jankovic", createPharmacy.GetLastRowName());
            Assert.Equal("Vojvode Misica", createPharmacy.GetLastRowAddress());
            Assert.Equal("wwww.jankovic.com", createPharmacy.GetLastRowUrl());
        }

        [SkippableFact]
        public void TestInvalidName()
        {
            Skip.If(skippable);
            createPharmacy.AddButtonClick();
            createPharmacy.WaitUntilModalAppears();
            createPharmacy.InsertUrl("wwww.jankovic.com");         
            createPharmacy.InsertAddress("Vojvode Misica");
            createPharmacy.SubmitForm();

            createPharmacy.WaitForAlertDialog();         
            Assert.Equal(createPharmacy.GetDialogMessage(), Pages.CreatePharmacyPage.InvalidNameMessage);     
            createPharmacy.ResolveAlertDialog();         
            Assert.Equal(driver.Url, Pages.CreatePharmacyPage.URI);  
        }

        [SkippableFact]
        public void TestInvalidAddress()
        {
            Skip.If(skippable);
            createPharmacy.AddButtonClick();
            createPharmacy.WaitUntilModalAppears();
            createPharmacy.InsertName("Jankovic");          
            createPharmacy.InsertUrl("wwww.jankovic.com");
            createPharmacy.SubmitForm();

            createPharmacy.WaitForAlertDialog();         
            Assert.Equal(createPharmacy.GetDialogMessage(), Pages.CreatePharmacyPage.InvalidAddressMessage);    
            createPharmacy.ResolveAlertDialog();        
            Assert.Equal(driver.Url, Pages.CreatePharmacyPage.URI);  
        }

        [SkippableFact]
        public void TestInvalidUrl()
        {
            Skip.If(skippable);
            createPharmacy.AddButtonClick();
            createPharmacy.WaitUntilModalAppears();
            createPharmacy.InsertName("Jankovic");        
            createPharmacy.InsertAddress("Vojvode Misica");
            createPharmacy.SubmitForm();

            createPharmacy.WaitForAlertDialog();     
            Assert.Equal(createPharmacy.GetDialogMessage(), Pages.CreatePharmacyPage.InvalidUrlMessage);     
            createPharmacy.ResolveAlertDialog();      
            Assert.Equal(driver.Url, Pages.CreatePharmacyPage.URI);   
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
