using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalEndToEndTests
{
    public class ManagerRoomEquipmentRelocationDynamicTest : IDisposable
    {
        private readonly IWebDriver driver;

        private Pages.LoginPage loginPage;
        private Pages.ManagerHomePage managerHomePage;
        private Pages.HospitalMapPage hospitalPage;
        private Pages.RoomEquipmentRelocationPage roomEquipmentRelocationPage;

        public ManagerRoomEquipmentRelocationDynamicTest()
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
            //driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));
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
            Assert.True(managerHomePage.HospitalMapCardDisplayed());

            managerHomePage.ClickHospitalMapCard();
            managerHomePage.WaitUntilHospitalMapRedirect();

            hospitalPage = new Pages.HospitalMapPage(driver);

            hospitalPage.ClickSideBarButton();
            hospitalPage.ClickSideBarItem();
            hospitalPage.WaitUntilSideBarItemRedirect();

        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestValidQuantity()
        {
            roomEquipmentRelocationPage = new Pages.RoomEquipmentRelocationPage(driver);
            roomEquipmentRelocationPage.SelectFirstStep();
            roomEquipmentRelocationPage.ClickFirstButton();
            driver.Manage().Timeouts().ImplicitWait= new TimeSpan(5000);
            roomEquipmentRelocationPage.WaitUntilSecondStepLoad();
            roomEquipmentRelocationPage.SelectSecondStep();
            roomEquipmentRelocationPage.WaitUntilSecondButtonLoad();
            roomEquipmentRelocationPage.ClickSecondButton();
            roomEquipmentRelocationPage.WaitUntilThirdStepLoad();
            roomEquipmentRelocationPage.InputThirdStep("50");
            roomEquipmentRelocationPage.WaitUntilThirdButtonLoad();
            roomEquipmentRelocationPage.ClickThirdButton();
            roomEquipmentRelocationPage.WaitUntilThirdButtonLoad();
            try
            {
                roomEquipmentRelocationPage.CheckQuantity();

            }
            catch (OpenQA.Selenium.NoSuchWindowException ev)
            {
                Assert.True(roomEquipmentRelocationPage.Step4Displayed());
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                Assert.True(roomEquipmentRelocationPage.Step4Displayed());
            }
            Assert.Equal("http://localhost:4200/roomManagment/moveEquipment", driver.Url);
        }


        [Fact]
        public void TestInvalidQuantity()
        {
            roomEquipmentRelocationPage = new Pages.RoomEquipmentRelocationPage(driver);
            roomEquipmentRelocationPage.SelectFirstStep();
            roomEquipmentRelocationPage.ClickFirstButton();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(5000);
            roomEquipmentRelocationPage.WaitUntilSecondStepLoad();
            roomEquipmentRelocationPage.SelectSecondStep();
            roomEquipmentRelocationPage.WaitUntilSecondButtonLoad();
            roomEquipmentRelocationPage.ClickSecondButton();
            roomEquipmentRelocationPage.WaitUntilThirdStepLoad();
            roomEquipmentRelocationPage.InputThirdStep("500");
            roomEquipmentRelocationPage.WaitUntilThirdButtonLoad();
            roomEquipmentRelocationPage.ClickThirdButton();
            try
            {
                roomEquipmentRelocationPage.CheckQuantity();

            }
            catch (OpenQA.Selenium.NoSuchWindowException ev)
            {
                Assert.False(roomEquipmentRelocationPage.Step4Displayed());
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                Assert.False(roomEquipmentRelocationPage.Step4Displayed());
            }
            Assert.Equal("http://localhost:4200/roomManagment/moveEquipment", driver.Url);
        }


    }
}
