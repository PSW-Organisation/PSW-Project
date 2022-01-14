using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalEndToEndTests.Pages
{
    public class ManagerHomePage
    {
        private readonly IWebDriver driver;
        public string ManagerHomepageURI { get { return "http://localhost:4200/home"; } }
        private IWebElement MaliciousCard => driver.FindElement(By.Name("maliciousCard"));
        private IWebElement FeedbackCard => driver.FindElement(By.Name("feedbackCard"));

        public bool MaliciousCardDisplayed()
        {
            return MaliciousCard.Displayed;
        }

        public bool FeedbackCardDisplayed()
        {
            return FeedbackCard.Displayed;
        }

        public void ClickMaliciousCard()
        {
            MaliciousCard.Click();
        }

        public void ClickFeedbackCard()
        {
            FeedbackCard.Click();
        }

        public ManagerHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilMaliciousRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("malicious"));
        }

        public void WaitUntilFeedbackRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("feedback"));
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);
    }
}
