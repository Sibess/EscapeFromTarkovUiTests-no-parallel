using EscapeFromTarkovUiTests.PageObjects.HomePage;
using EscapeFromTarkovUiTests.PageObjects.WikiPage.AK_74MPage;
using OpenQA.Selenium;


namespace EscapeFromTarkovUiTests.PageObjects.WikiPage
{
    public class Wiki : Home
    {
        private IWebDriver _driver;

        public Wiki(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _driver.SwitchTo().Window(driver.WindowHandles[1]);

        }

        public AK_74M AK_74M => new AK_74M(_driver);

        public void ClickWikiLink(string linkName)
        {
             new BaseElement(By.XPath($"//a[contains(text(),'{linkName}')]"), $"'{linkName}' Wiki link", _driver).Click();
        }

        public void ClickWeaponLink(string weaponName)
        {
            new BaseElement(By.XPath($"(//a[@title='{weaponName}'][normalize-space()='{weaponName}'])[1]"), $"'{weaponName}' Weapon link", _driver).Click();
        }


    }
}