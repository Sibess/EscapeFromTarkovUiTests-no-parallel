using OpenQA.Selenium;

namespace EscapeFromTarkovUiTests.PageObjects.ExternalPages
{
    public class ExternalPages
    {
       protected IWebDriver _driver;
        public ExternalPages(IWebDriver driver)
        {
            _driver = driver;
        }
        public Youtube Youtube => new Youtube(_driver);
    }
}
