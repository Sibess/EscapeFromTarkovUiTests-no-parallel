using NUnit.Framework;
using NUnit.Framework.Internal;

namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class WikiTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldOpe2nError208Page()
        {
            Home.ClickHeaderButton("Wiki");
            Home.Wiki.ClickWikiLink("Weapons");
            Home.Wiki.ClickWeaponLink("AK-74M");
            Assert.IsTrue(Home.Wiki.AK_74M.IsValidCartridgeDisplayed("5.45x39"));
        }
    }
}
