using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalEndToEndTests.Pages
{
    public class MaliciousPage
    {
        private readonly IWebDriver driver;
        public string MaliciousPageURI { get { return "http://localhost:4200/malicious"; } }
        private IWebElement MaliciousCard => driver.FindElement(By.Name("maliciousCard"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));
        private IWebElement ToastrSuccessAlert => driver.FindElement(By.ClassName("toast-success"));


        public void EnsureRowsAreDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void ClickBlockMalicious()
        {
            Rows[0].FindElement(By.TagName("button")).Click();
        }

        public bool DisabledButtonDisplayed()
        {
            return !Rows[0].FindElement(By.TagName("button")).Enabled;
        }

        public MaliciousPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilToastrSuccess()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("toast-success")));
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);
    }
}
