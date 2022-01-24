using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IntegrationAPISeleniumTests.Pages
{
    public class CreatePharmacyPage
    {
        private IWebDriver driver;
        private IWebElement ButtonAdd => driver.FindElement(By.Id("add"));
        private IWebElement NameElement => driver.FindElement(By.Id("name"));
        private IWebElement AddressElement => driver.FindElement(By.Id("address"));
        private IWebElement UrlElement => driver.FindElement(By.Id("url"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("yes"));
        private IWebElement Table => driver.FindElement(By.Id("pharmacies"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='pharmacies']/tbody/tr"));
        private IWebElement LastRowName => driver.FindElement(By.XPath("//table[@id='pharmacies']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowAddress => driver.FindElement(By.XPath("//table[@id='pharmacies']/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowUrl=> driver.FindElement(By.XPath("//table[@id='pharmacies']/tbody/tr[last()]/td[4]"));

        public const string URI = "http://localhost:4200/addPharmacy";
        public const string InvalidNameMessage = "Name should be defined!";
        public const string InvalidUrlMessage = "Url should be defined!";
        public const string InvalidAddressMessage = "Address should be defined!";

        public CreatePharmacyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddButtonClick()
        {
            ButtonAdd.Click();
        }

        public void InsertName(string name)
        {

           NameElement.SendKeys(name);
        }

        public void InsertAddress(string address)
        {
            AddressElement.SendKeys(address);
        }

        public void InsertUrl(string url)
        {
            UrlElement.SendKeys(url);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public void WaitUntilSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("pharmacies"))));
        }

        public void WaitUntilModalAppears()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("name"))));

        }

        public int PharmaciesCount()
        {
            return Rows.Count;
        }

        public string GetLastRowName()
        {
            return LastRowName.Text;
        }

        public string GetLastRowAddress()
        {
            return LastRowAddress.Text;
        }

        public string GetLastRowUrl()
        {
            return LastRowUrl.Text;
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }
    }
}
