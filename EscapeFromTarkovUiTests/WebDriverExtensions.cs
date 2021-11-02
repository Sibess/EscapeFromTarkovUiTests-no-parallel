using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTarkovUiTests
{
   public static class WebDriverExtensions
    {
        public static WebDriverWait GetWait(this IWebDriver driver, TimeSpan timeout) => new WebDriverWait(driver, timeout);

    }
}
