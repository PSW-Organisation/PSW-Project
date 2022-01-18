using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalEndToEndTests.Pages
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public string PatientProfileURI { get { return "http://localhost:4200/profile"; } }
        private IWebElement TextAreaElement => driver.FindElement(By.Name("textarea"));
        private IWebElement RadioAnonymousElement => driver.FindElement(By.Id("anonymousRadioYes"));
        private IWebElement RadioPublishElement => driver.FindElement(By.Id("publishRadioYes"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Name("submit"));
        private IWebElement ToastrErrorAlert => driver.FindElement(By.ClassName("toast-error"));
        private IWebElement ToastrSuccessAlert => driver.FindElement(By.ClassName("toast-success"));

        public bool TextAreaElementDisplayed()
        {
            return TextAreaElement.Displayed;
        }
        public bool RadioAnonymousElementDisplayed()
        {
            return RadioAnonymousElement.Displayed;
        }
        public bool RadioPublishElementDisplayed()
        {
            return RadioPublishElement.Displayed;
        }
        public bool SubmitButtonDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }
        public bool ToastrErrorAlertDisplayed()
        {
            return ToastrErrorAlert.Displayed;
        }
        public bool ToastrSuccessAlertDisplayed()
        {
            return ToastrSuccessAlert.Displayed;
        }
        public void ClickSubmitButton()
        {
            SubmitButtonElement.Click();
        }

        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TypeTextArea(string text)
        {
            TextAreaElement.SendKeys(text);
        }
        public void ClickRadioAnonymous()
        {
            RadioAnonymousElement.Click();
        }
        public void ClickRadioPublish()
        {
            RadioPublishElement.Click();
        }
        public void WaitUntilTextAreaDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("textarea")));
        }
        public void WaitUntilToastrSuccess()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("toast-success")));
        }

        public void WaitUntilToastrError()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("toast-error")));
        }

        internal bool DisabledButtonDisplayed()
        {
            return !SubmitButtonElement.Enabled;
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);
    }
}
