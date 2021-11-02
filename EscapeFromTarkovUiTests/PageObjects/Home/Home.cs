using OpenQA.Selenium;
using EscapeFromTarkovUiTests.PageObjects.MerchPage;
using EscapeFromTarkovUiTests.PageObjects.RatingsPage;
using EscapeFromTarkovUiTests.PageObjects.SupportPage;
using EscapeFromTarkovUiTests.PageObjects.WikiPage;
using EscapeFromTarkovUiTests.PageObjects.PreorderPage;

namespace EscapeFromTarkovUiTests.PageObjects.HomePage
{
    public class Home
    {
        protected IWebDriver _driver;
        public Home(IWebDriver driver)
        {
            _driver = driver;
        }

        public Merch Merch => new Merch(_driver);

        public Ratings Ratings => new Ratings(_driver);

        public Support Support => new Support(_driver);

        public Wiki Wiki => new Wiki(_driver);

        public Preorder Preorder => new Preorder(_driver);

        private BaseElement teaser3 => new BaseElement(By.Id("banner_39_youtube"), "Youtube teaser 3", _driver);

        private BaseElement preoderButton => new BaseElement(By.XPath("//img[@alt='button']"),  "Preoder button", _driver);
       

        public void ClickTeaser3()
        {
            teaser3.Click();
        }

        public void ClickPreorderButton()
        {
            preoderButton.Click();
        }

        public void ClickHeaderButton(string headerButtonName)
        {
          new BaseElement(By.XPath($"//a[normalize-space()='{headerButtonName}']"), $"'{headerButtonName}' header button", _driver).Click();
        }
  
    }
}
