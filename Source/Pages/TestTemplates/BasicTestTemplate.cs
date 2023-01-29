using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace JoeTesting.Tests.TestTemplates
{
    public class BasicTestTemplate
    {
        public IWebDriver driver;

        public const string mainPage = "https://joemonster.org/";
        public const string logPage = "https://joemonster.org/logowanie";
        public const string badUrl = "https://joemonster.org/BadUrlTesting";

        const string XmlPath = @"C:\JoeMonstrerUserCredencials.xml";
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        public void GoToPage(string page = mainPage, bool acceptCookies = true)
        {
            driver.Navigate().GoToUrl(page);
            if (acceptCookies) AcceptCookies();
        }

        private void AcceptCookies()
        {
            driver.FindElement(By.CssSelector("#sd-cmp > div.sd-cmp-2E0Ye > div > div > div > div > div > div > div.sd-cmp-WgGhS.sd-cmp-TVq-W > div:nth-child(2) > button:nth-child(2) > span")).Click();           
        }

        public void LogIntoPage()
        {
            string username = GetNodeValue("Username");
            string password = GetNodeValue("Password");

            GoToPage(logPage);

            driver.FindElement(By.CssSelector("[name='_username']")).SendKeys(username);
            var passField = driver.FindElement(By.CssSelector("[name='_password']"));
            passField.SendKeys(password);
            
            passField.Submit();
        }

        private string GetNodeValue(string nodeName)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(XmlPath);
            XmlNodeList? xnList = xmlDoc.SelectNodes($"root/UserCredencials/{nodeName}");

            return xnList.OfType<XmlNode>()
                         .First().InnerText;
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
