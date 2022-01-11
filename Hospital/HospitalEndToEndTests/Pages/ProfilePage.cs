using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalEndToEndTests.Pages
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;
        public string ProfilePageURI { get { return "http://localhost:4200/profile"; } }
        private IWebElement NavBar => driver.FindElement(By.Name("navBar"));
        private IWebElement AppointmentsLink => driver.FindElement(By.Name("appointmentsLink"));
       

       
        public void ClickAppointmentsLink()
        {
            AppointmentsLink.Click();
        }

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilAppointmentsRedirect()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("appointments"));
        }

    }

}
