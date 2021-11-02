using EscapeFromTarkovUiTests.PageObjects.HomePage;
using OpenQA.Selenium;

namespace EscapeFromTarkovUiTests.PageObjects.PreorderPage
{
    public class Preorder : Home
    {
        public Preorder(IWebDriver driver) : base(driver)
        {
        }

        private BaseElement registrationRequirementText => new BaseElement(By.XPath("//h4[contains(text(),'You need to register first, and then log in to you')]"), "Requirement for registration text", _driver);
        
        public void SelectPreorderEdition(string editionName)
        {
            new BaseElement(By.XPath($"//div[@data-selected='{editionName}']"), $"'{editionName}' preorder button", _driver).Click();
        }
        public bool IsRegistrationRequirementTextDisplayed()
        {
            return registrationRequirementText.IsDisplayed();
        }
    }
}
