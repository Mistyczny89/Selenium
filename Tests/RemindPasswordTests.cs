using JoeTesting.Tests.TestTemplates;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JoeTesting.Tests
{
    internal class RemindPasswordTests : BasicTestTemplate
    {
        [Test]
        public void EmailWindowBeforeClick()
        {
            GoToPage(logPage);
            Assert.That(driver.FindElement(By.CssSelector("input[name='email']")).Displayed, Is.False);
        }

        [Test]
        public void EmailWindowAfterClick()
        {
            GoToPage(logPage);
            driver.FindElement(By.CssSelector("a[class='tiny remindPasswordButton']")).Click();

            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.FindElement(By.CssSelector("input[name='email']")).Displayed);

            Assert.That(driver.FindElement(By.CssSelector("input[name='email']")).Displayed, Is.True);

        }

    }
}
