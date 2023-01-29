using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;

namespace JoeTesting.Tests
{
    internal class GoToUrlTests : BasicTestTemplate
    {
        [Test]
        public void GoToUrl()
        {
            GoToPage();
            Assert.That(driver.Url, Is.EqualTo(mainPage), "URL is not correct");
        }
    }
}
