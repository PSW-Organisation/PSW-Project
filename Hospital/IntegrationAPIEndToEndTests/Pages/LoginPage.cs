using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationAPISeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public string ManagerLoginURI { get { return "http://localhost:4200/"; } }
        private IWebElement UsernameElement => driver.FindElement(By.Name("username"));
        private IWebElement PasswordElement => driver.FindElement(By.Name("password"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Name("login"));
        private IWebElement ToastrErrorAlert => driver.FindElement(By.ClassName("toast-error"));
        private IWebElement ToastrSuccessAlert => driver.FindElement(By.ClassName("toast-success"));

        public bool UsernameElementDisplayed()
        {
            return UsernameElement.Displayed;
        }
        public bool PasswordElementDisplayed()
        {
            return PasswordElement.Displayed;
        }
        public bool SubmitButtonElementDisplayed()
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

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TypeUsername(string username)
        {
            UsernameElement.SendKeys(username);
        }
        public void TypePassword(string password)
        {
            PasswordElement.SendKeys(password);
        }

        public void WaitUntilHomeRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("home"));
        }

        public void WaitUntilToastrError()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("toast-error")));
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);
    }
}

