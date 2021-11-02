using EscapeFromTarkovUiTests.PageObjects.HomePage;
using OpenQA.Selenium;

namespace EscapeFromTarkovUiTests.PageObjects.MerchPage
{
    public class Merch : Home
    {
        public Merch(IWebDriver driver) : base(driver)
        {
            _driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        private BaseElement booksButton => new BaseElement(By.XPath("//a[contains(text(),'Книги')]"), "'Books' button", _driver);
        
        public void ClickBooksButton()
        {
            booksButton.Click();
        }

        public bool IsValidMasterOfTheNightBookPriceDisplayed(string bookPrice)
        {
            new BaseElement(By.XPath($"//app-product-card[@class='ng-tns-c6-2 ng-tns-c9-9']//span[@class='price'][contains(text(),'{bookPrice}')]"), "'Master Of TheNight' book price", _driver).WaitForElementIsVisible();
            return new BaseElement(By.XPath($"//app-product-card[@class='ng-tns-c6-2 ng-tns-c9-9']//span[@class='price'][contains(text(),'{bookPrice}')]"), "'Master Of TheNight' book price", _driver).IsDisplayed();         
        }
    }
}
