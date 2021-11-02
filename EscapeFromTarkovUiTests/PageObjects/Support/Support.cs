using EscapeFromTarkovUiTests.PageObjects.HomePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EscapeFromTarkovUiTests.PageObjects.Error208Page;

namespace EscapeFromTarkovUiTests.PageObjects.SupportPage
{
    public class Support : Home
    {
        //private IWebDriver _driver;

        public Support(IWebDriver driver) : base(driver)
        {
           // _driver = driver;

        }

        public Error208 Error208 => new Error208(_driver);
        private BaseElement error208Link => new BaseElement(By.XPath("//div[@id='support']//div[1]//div[1]//ul[1]//li[1]//a[1]"), "'Error 208' link", _driver);

        public void Clickerror208Link()
        {
            error208Link.Click();
        }

        //public void ClickHeaderButton(string headerButtonName)
        //{
        //    new BaseElement(By.XPath($"//a[normalize-space()='{headerButtonName}']"), $"'{headerButtonName}' header button", _driver).Click();
        //}

        //public bool IsValidMasterOfTheNightBookPriceDisplayed(string bookPrice)
        //{
        //    new BaseElement(By.XPath($"//app-product-card[@class='ng-tns-c6-2 ng-tns-c9-9']//span[@class='price'][contains(text(),'{bookPrice}')]"), "'Master Of TheNight' book price", _driver).WaitForElementIsVisible();
        //    return new BaseElement(By.XPath($"//app-product-card[@class='ng-tns-c6-2 ng-tns-c9-9']//span[@class='price'][contains(text(),'{bookPrice}')]"), "'Master Of TheNight' book price", _driver).IsDisplayed();
        //}
    }
}
