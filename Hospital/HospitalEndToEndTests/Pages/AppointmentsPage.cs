using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalEndToEndTests.Pages
{
    public class AppointmentsPage
    {
        private readonly IWebDriver driver;
        public string AppointmentsPageURI { get { return "http://localhost:4200/appointments"; } }
        private IWebElement NavBar => driver.FindElement(By.Name("navBar"));
        private IWebElement AppointmentsLink => driver.FindElement(By.Name("appointmentsLink"));
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));
        private IWebElement ToastrSuccessAlert => driver.FindElement(By.ClassName("toast-success"));


        public void EnsureRowsAreDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 2;
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

        public void ClickAppointmentsLink()
        {
            AppointmentsLink.Click();
        }

        public void ClickCancelAppointment()
        {
            Rows[2].FindElement(By.Name("cancelButton")).Click();
        }

        public bool DisabledButtonDisplayed()
        {
            return !Rows[2].FindElement(By.Name("cancelButton")).Enabled;
        }

        public AppointmentsPage(IWebDriver driver)
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

