using EscapeFromTarkovUiTests.PageObjects.HomePage;
using EscapeFromTarkovUiTests.PageObjects.SupportPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EscapeFromTarkovUiTests.PageObjects.Error208Page
{
    public class Error208 : Support
    {

        public Error208(IWebDriver driver) : base(driver)
        {

        }

        public bool IsValidPageName()
        {
            return new BaseElement(By.XPath("//h1[normalize-space()='Error 208']"), "Levels of players", _driver).IsDisplayed();

        }

    }
}