using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace JoeTesting.Tests
{
    public class BadUrlTests : BasicTestTemplate
    {
        [Test]
        public void CheckForError404()
        {
            Regex errorMsg = new(@"\>.+\s+404\<");

            GoToPage(badUrl, false);

            Assert.That(errorMsg.IsMatch(driver.PageSource), Is.True);
        }

    }
}
