using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace JoeTesting.Tests
{
    public class HomePageSearchTests : BasicTestTemplate
    {
        private const string SearchValue = "funny cat";
        private readonly string findRegex = @$"Znaleziono \<strong\>\d+\<\/strong\>\s*wyników\s*dla zapytania\s+\<strong\>{SearchValue}\<\/strong>";

        [Test]
        public void CheckIfThereIsInfoAboutSearchResults()
        {
            FindFunnyCats();
            Assert.That(Regex.IsMatch(driver.PageSource, findRegex), Is.True); ;
        }

        [Test]
        public void CheckIfThereIsCorrectUrlAfterSearch()
        {
            FindFunnyCats();
            Assert.That(driver.Url, Does.Contain(SearchValue.Replace(' ', '+')), "URL is not correct");
        }

        private void FindFunnyCats()
        {
            GoToPage();
            var searchfield = driver.FindElement(By.CssSelector("[class=search-form-query]"));
            searchfield.SendKeys(SearchValue);
            searchfield.Submit();
        }


    }
}
