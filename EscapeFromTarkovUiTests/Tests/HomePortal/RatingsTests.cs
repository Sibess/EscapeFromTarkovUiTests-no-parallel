using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class RatingsTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldDispljayIntegerLevels()
        {
            Home.ClickHeaderButton("Ratings");
            Home.Ratings.ClickTop100Dropdown();
            Home.Ratings.SelectDropdownValue("kills");
            Assert.AreEqual(100, Home.Ratings.IsValidNumberOfPlayersDisplayed(), "Number of Players is not 100");
            Assert.IsTrue(Home.Ratings.ArelevelsIntegers());
        }
    }
}
