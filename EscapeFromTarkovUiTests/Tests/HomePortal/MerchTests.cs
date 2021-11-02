using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class MerchTests : BaseTest
    {
        [Category("Smoke")]
        [Test]      
        public void ShouldDisplayValidBookPrice()
        {
            Home.ClickHeaderButton("Merch");
            Home.Merch.ClickBooksButton();
            Assert.IsTrue(Home.Merch.IsValidMasterOfTheNightBookPriceDisplayed("260₽"), "'Master Of TheNight' book price is not valid");
        }
    }
}
