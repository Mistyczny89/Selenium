using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JoeTesting.Tests
{
    internal class LogIntoPageTests : BasicTestTemplate
    {
        [Test]
        public void UrlAfterLogging()
        {
            LogIntoPage();
            Assert.That(driver.Url, Is.EqualTo(mainPage + "user.php"), "URL is not correct");
        }

        [Test]
        public void NickComparationAfterLogging()
        {
            LogIntoPage();
            string shownSmallNick = driver.FindElement(By.CssSelector("a[class='linkToProfile']")).Text;  
            string shownBigNick = driver.FindElement(By.CssSelector(".nickibig")).Text;

            Assert.That(shownBigNick, Is.EqualTo(shownSmallNick));
        }

        [Test]
        public void CheckIfProfileUrlContainsUserName()
        {
            LogIntoPage();
            driver.FindElement(By.CssSelector("[class=linkToProfile]")).Click();
            string userNick = driver.FindElement(By.CssSelector("[class='linkToProfile']")).Text;
            Assert.That(driver.Url, Does.Contain(userNick));
        }
    }
}
