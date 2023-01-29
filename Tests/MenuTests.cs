using JoeTesting.Tests.TestTemplates;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JoeTesting.Tests
{
    public class MenuTests : BasicTestTemplate
    {
        readonly List<(string menu, string clas, string url)> menus = new()
        {
            ( "Glowna", "menuJMSelected", string.Empty ),
            ( "galeria", "menuJMunselected", "mg/lastup"),
            ( "monsterTV", "menuJMunselected", "filmy" ),
            ( "forum", "menuJMunselected", "forum/" ),
            ( "skoczek", "menuJMunselected", string.Empty),
            ( "blogi", "menuJMunselected", "blog/" ),
            ( "bojownicy", "menuJMunselected", "ludzie.php" ),
            ( "szaffa", "menuJMunselected", "szaffa" ),
        };        

        [Test]
        public void CheckForAllMenusTest()
        {
            GoToPage();

            foreach (var (menu, clas, _) in menus)
            {
                string cssSelector = $"[class='{clas}'] > a[onclick*={menu}]";
                Assert.That(driver.FindElements(By.CssSelector(cssSelector)).Count, Is.EqualTo(1), $"Menu {menu} not found!");
            };
        }

        [Test]
        public void CheckUrlsAfterClick()
        {
            GoToPage();
            foreach (var (menu, clas, url) in menus.Where(d => d.menu != "skoczek"))
            {
                string cssSelector = $"[class='{clas}'] > a[onclick*={menu}]";
                driver.FindElement(By.CssSelector(cssSelector)).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3); // Workaround for slow internet connection
                Assert.That(driver.Url, Is.EqualTo($"{mainPage}{url}"), "URL is not correct");
            }            
        }
    }


}
