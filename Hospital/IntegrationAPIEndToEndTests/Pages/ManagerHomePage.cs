﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IntegrationAPISeleniumTests.Pages
{
   public class ManagerHomePage
   {
        private readonly IWebDriver driver;
        public string ManagerHomepageURI { get { return "http://localhost:4200/home"; } }
        private IWebElement PharmaciesButton => driver.FindElement(By.Id("pharmacies"));
        private IWebElement PharmaciesCard => driver.FindElement(By.Name("pharmacies"));

        private IWebElement ComplaintsButton => driver.FindElement(By.Id("complaintsButton"));

        public void PharmaciesCardDisplayed()
        {
            PharmaciesButton.Click();
        }

        public void ComplaintsButtonClick()
        {
            ComplaintsButton.Click();
        }

        public ManagerHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilPharmaciesRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("pharmacies"));
        }

        public void Navigate(string url) => driver.Navigate().GoToUrl(url);

        }
}
