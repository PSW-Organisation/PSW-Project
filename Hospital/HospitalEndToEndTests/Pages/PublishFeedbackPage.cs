using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalEndToEndTests.Pages
{
    public class PublishFeedbackPage
    {
        private readonly IWebDriver driver;
        public string FeedbackPageURI { get { return "http://localhost:4200/feedback"; } }
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));
        private IWebElement ToastrSuccessAlert => driver.FindElement(By.ClassName("toast-success"));
        private IWebElement hideButton => driver.FindElement(By.TagName("hideButton"));

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

        public void ClickPublishFeedback()
        {
            Rows[0].FindElement(By.TagName("button")).Click();
        }

        public bool HideButtonDisplayed()
        {
            return Rows[0].FindElement(By.Name("hideButton")).Displayed;
        }

        public PublishFeedbackPage(IWebDriver driver)
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
