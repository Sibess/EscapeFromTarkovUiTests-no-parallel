using EscapeFromTarkovUiTests.PageObjects.WikiPage;
using OpenQA.Selenium;

namespace EscapeFromTarkovUiTests.PageObjects.WikiPage.AK_74MPage
{
    public class AK_74M : Wiki
    {
        public AK_74M(IWebDriver driver) : base(driver)
        {

        }

        public bool IsValidCartridgeDisplayed(string cartridge)
        {
            return new BaseElement(By.XPath($"(//h1[normalize-space()='AK-74M {cartridge} assault rifle'])[1]"), "AK-74M 5.45x39 assault rifle", _driver).IsDisplayed();

        }

    }
}
