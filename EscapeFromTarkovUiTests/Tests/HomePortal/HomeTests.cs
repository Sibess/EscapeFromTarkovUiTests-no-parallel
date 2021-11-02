using NUnit.Framework;
using NUnit.Framework.Internal;


namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class HomeTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldPlayTeaser3()
        {
            Home.ClickTeaser3();
            ExternalPages.Youtube.ClickPlayButton();
            Assert.IsTrue(ExternalPages.Youtube.IsVideoPlaying(), "Youtube Video wasn't playing");
        }
    }
}
