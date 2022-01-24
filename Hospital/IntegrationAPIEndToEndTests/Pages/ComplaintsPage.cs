using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace IntegrationAPIEndToEndTests.Pages
{
    public class ComplaintsPage
    {
        private IWebDriver driver;
        private IWebElement ButtonAdd => driver.FindElement(By.Id("add"));
        private SelectElement PharmacyElement => new SelectElement(driver.FindElement(By.Id("pharmacy")));
        private IWebElement TitleElement => driver.FindElement(By.Id("title"));
        private IWebElement ContentElement => driver.FindElement(By.Id("content"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));
        private IWebElement Table => driver.FindElement(By.Id("complaints"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='complaints']/tbody/tr"));
        private IWebElement LastRowDate => driver.FindElement(By.XPath("//table[@id='complaints']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowTitle => driver.FindElement(By.XPath("//table[@id='complaints']/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowContent => driver.FindElement(By.XPath("//table[@id='complaints']/tbody/tr[last()]/td[4]"));

        public const string InvalidTitleMessage = "Title should be defined!";
        public const string InvalidContentMessage = "Content should be defined!";
        public const string InvalidPharmacyMessage = "Pharmacy should be selected!";

        public ComplaintsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLastRowDate()
        {
            return LastRowDate.Text;
        }

        public string GetLastRowTitle()
        {
            return LastRowTitle.Text;
        }

        public string GetLastRowContent()
        {
            return LastRowContent.Text;
        }

        public int ComplaintsCount()
        {
            return Rows.Count;
        }

        public void AddButtonClick()
        {
            ButtonAdd.Click();
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(3000);
        }

        public void SelectPharmacy(string pharmacyName)
        {
            bool pharmacyExists = false;
            foreach(var option in PharmacyElement.AllSelectedOptions)
            {
                if (option.Text.Equals(pharmacyName))
                {
                    pharmacyExists = true;
                }
            }
            if(pharmacyExists)
            {
                PharmacyElement.SelectByText(pharmacyName);
            }
        }

        public void InsertTitle(string title)
        {
            TitleElement.SendKeys(title);
        }

        public void InsertContent(string content)
        {
            ContentElement.SendKeys(content);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public void WaitUntilSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("complaints"))));
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
