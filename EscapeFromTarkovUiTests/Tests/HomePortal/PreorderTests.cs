using NUnit.Framework;

namespace EscapeFromTarkovUiTests.Tests.HomePortal
{
    [TestFixture]
    [Parallelizable]
    public class PreorderTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldDisplayValidRegistrationRequirement()
        {
            Home.ClickPreorderButton();
            Home.Preorder.SelectPreorderEdition("standard");
            Home.Preorder.IsRegistrationRequirementTextDisplayed();
        }
    }
}
