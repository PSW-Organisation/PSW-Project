using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace IntegrationAPIEndToEndTests.Pages
{
    public class TenderPage
    {
        private readonly IWebDriver driver;
        private IWebElement ButtonAdd => driver.FindElement(By.Id("add_bttn"));
        private IWebElement TenderItemAddButton => driver.FindElement(By.Id("item_button"));
        private IWebElement TenderPostButton => driver.FindElement(By.Id("post_button"));
        private IWebElement ItemAmmount => driver.FindElement(By.Id("item_ammount"));
        private IWebElement DateUntill => driver.FindElement(By.Id("date_input"));

        private ReadOnlyCollection<IWebElement> TenderName => driver.FindElements(By.Id("tender_name"));
        private ReadOnlyCollection<IWebElement> TenderItem => driver.FindElements(By.Id("tender_item"));
        //private ReadOnlyCollection<IWebElement> TenderDate => driver.FindElements(By.Id("tender_date"));

        private IWebElement ItemName => driver.FindElement(By.Id("item_name"));
        public ReadOnlyCollection<IWebElement> TenderCards => driver.FindElements(By.Id("tender_card"));

        public TenderPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public int GetCardCount()
        {
            return TenderCards.Count;
        }
        public bool CheckNameExist(string name)

        {
            List<string> names = new List<string>();
            foreach(IWebElement e in TenderName)
            {
                string n = e.Text;

                if (n.Equals(name))
                {
                    return true;
                }
            }
            return false ;
        }
        public bool CheckItemExist(string name)
        {
            List<string> names = new List<string>();
            foreach (IWebElement e in TenderItem)
            {
                string n = e.Text;

                if (n.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void ButtonAddClick()
        {
            ButtonAdd.Click();
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(3000);
        }
       
        public void TenderItemAddButtonClick()
        {
            TenderItemAddButton.Click();
        }
        public void SelectDate()
        {
            var today = DateTime.Now.ToString("dd/MM/yyyy");
            

            DateUntill.Click();
            driver.FindElement(By.LinkText(today)).Click();

        }
        public void WaitUntilSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("tender_card"))));
        }

        public void InsertName(string name)
        {
            ItemName.SendKeys(name);
        }
        public void InsertAmmount(string ammount)
        {
            ItemAmmount.SendKeys(ammount);
        }

        public void PostButtonClick()
        {
            TenderPostButton.Click();
        }

    }
}
