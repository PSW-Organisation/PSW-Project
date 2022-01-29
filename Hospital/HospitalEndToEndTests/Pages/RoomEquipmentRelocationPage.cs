using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace HospitalEndToEndTests.Pages
{
    public class RoomEquipmentRelocationPage
    {
        private readonly IWebDriver driver;
        public string MoveEquipmentURI { get { return "http://localhost:4200/roomManagment/moveEquipment"; } }

        //private SelectElement FirstStep => new SelectElement(driver.FindElement(By.Name("step1")));
        private IWebElement FirstStep => driver.FindElement(By.XPath("//*[starts-with(@name,'step')]"));
        private IWebElement FirstStepSecond => driver.FindElement(By.XPath("//span[contains(text(),' Equipment: Picks - Quantity 300 ')]"));

        private IWebElement SecondStep => driver.FindElement(By.XPath("//mat-select[starts-with(@name,'step2')]"));

        private IWebElement ThirdStep => driver.FindElement(By.Id("step3"));
        private IWebElement SecondStepSecond => driver.FindElement(By.XPath("//span[contains(text(),' Room: 16 - Equipment: Picks - Quantity 300 ')]"));

        private IWebElement FirstNext => driver.FindElement(By.Id("btn1"));

        private IWebElement SecondNext => driver.FindElement(By.Id("btn2"));

        private IWebElement ThirdNext => driver.FindElement(By.Id("btn3"));

        public void SelectFirstStep()
        {
            FirstStep.Click();
            FirstStepSecond.Click();
        }

        public void SelectSecondStep()
        {
            SecondStep.Click();
            SecondStepSecond.Click();
            //var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//mat-select[starts-with(@name,'step2')]"))).SendKeys(Keys.Return);
            //var wait1 = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//span[contains(text(),' Room: 16 - Equipment: Picks - Quantity 300 ')]"))).SendKeys(Keys.Return);
        }

        public void InputThirdStep(string amount)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("step3"))).SendKeys(amount);
        }


        public void ClickFirstButton()
        {
            FirstNext.Click();
        }
        
        public void ClickSecondButton()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(SecondNext);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("btn2"))).SendKeys(Keys.Return);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void ClickThirdButton()
        {
            //ThirdNext.Click();
            Actions a = new Actions(driver);
            a.MoveToElement(ThirdNext);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("btn3"))).SendKeys(Keys.Return);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public RoomEquipmentRelocationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WaitUntilSecondStepLoad()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[starts-with(@name,'step2')]")));
        }

        public void WaitUntilSecondButtonLoad()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btn2")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void WaitUntilThirdStepLoad()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("step3")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void WaitUntilThirdButtonLoad()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 3, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btn3")));
        }

        public void CheckQuantity()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("step4")));
        }

        public Boolean Step4Displayed()
        {
            try
            {
                return driver.FindElement(By.Id("step4")).Displayed;
            }
            catch (OpenQA.Selenium.NoSuchElementException ev)
            {
                return false;
            }
        
    }

        public void DynamicClick()
        {
            ThirdNext.SendKeys("/n");
            ThirdNext.SendKeys("{TAB}");
            ThirdNext.SendKeys("{TAB}");
            ThirdNext.SendKeys("{ENTER}");
        }


}

}
