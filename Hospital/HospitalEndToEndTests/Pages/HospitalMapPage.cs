using System;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace HospitalEndToEndTests.Pages
{
    public class HospitalMapPage
    {
        private readonly IWebDriver driver;
        public string HospitalMapURI { get { return "http://localhost:4200/roomManagment/hospitalExterior"; } }

        private IWebElement SideBarButton => driver.FindElement(By.Id("sidenavButton"));
        private IWebElement SideBarItem => driver.FindElement(By.Name("moveEquipment"));

        public void ClickSideBarButton()
        {
            SideBarButton.Click();
        }

        public void ClickSideBarItem()
        {
            SideBarItem.Click();
        }

        public HospitalMapPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilSideBarItemRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("moveEquipment"));
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);


    }
}
