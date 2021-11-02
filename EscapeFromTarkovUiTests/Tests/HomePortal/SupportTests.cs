using NUnit.Framework;
using NUnit.Framework.Internal;

namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class SupportTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldOpenError208Page()
        {
            Home.ClickHeaderButton("Support");
            Home.Support.Clickerror208Link();
            Assert.IsTrue(Home.Support.Error208.IsValidPageName());
        }
    }
}
