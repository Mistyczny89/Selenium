using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JoeTesting.Tests
{
    public class LogoTests : BasicTestTemplate
    {
        [Test]
        public void CheckLogoClick()
        {
            GoToPage();
            driver.FindElement(By.CssSelector("[class='logo']")).Click();

            Assert.That(driver.Url, Is.EqualTo(mainPage), "URL is not correct");
        }

        [Test]
        public void CheckLogoClickFromDifferentUrl()
        {
            GoToPage(logPage);
            driver.FindElement(By.CssSelector("[class='logo']")).Click();

            Assert.That(driver.Url, Is.EqualTo(mainPage), "URL is not correct");
        }

        [Test]
        public void CheckLogoClickFromBadUrl()
        {
            GoToPage(badUrl, false);
            driver.FindElement(By.CssSelector("[class='logo']")).Click();

            Assert.That(driver.Url, Is.EqualTo(mainPage), "URL is not correct");
        }

    }
}
