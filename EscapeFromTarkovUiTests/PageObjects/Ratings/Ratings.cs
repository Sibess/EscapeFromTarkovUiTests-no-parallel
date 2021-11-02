using EscapeFromTarkovUiTests.PageObjects.HomePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EscapeFromTarkovUiTests.PageObjects.RatingsPage
{
    public class Ratings : Home
    {
        public Ratings(IWebDriver driver) : base(driver)
        {
        }

        private BaseElement top100Dropdown => new BaseElement(By.XPath("//div[@class='category switcher inlinetop']"), "'Top 100' dropdown", _driver);

        public void ClickTop100Dropdown()
        {
            top100Dropdown.Click();
        }

        public void SelectDropdownValue(string dropdownValue)
        {
            new BaseElement(By.XPath($"//li[@data-val='{dropdownValue}']"), $"'{dropdownValue}' dropdown value", _driver).Click();
        }

        public int IsValidNumberOfPlayersDisplayed()
        {
            List<IWebElement> playerRows = _driver.FindElements(By.XPath("//div[@class='row table']//tbody//tr")).ToList();
            return playerRows.Count();
        }

        public bool ArelevelsIntegers()
        {
            new BaseElement(By.XPath("//div[@id='ratingLoader']"), "Levels of players", _driver).WaitForElementIsInvisible();
            var levels = _driver.FindElements(By.XPath("//tbody/tr/td[5]"));
            bool result = default;
            
            foreach (var lvl in levels)
            {
                if (int.TryParse(lvl.Text, out int rslt))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }       
            }
            return result;
        }
    }
}
