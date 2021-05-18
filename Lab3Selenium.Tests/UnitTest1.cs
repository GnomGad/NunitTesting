using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Lab3Selenium.Tests
{
    [TestFixture]
    public class Tests
    {
        ChromeOptions co = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome Dev\Application\chrome.exe" } ;
       
        IWebDriver _chrome;

        [OneTimeSetUp]
        public void Setup()
        {
            _chrome = new ChromeDriver(co);
        }

        [OneTimeTearDown]
        public void End()
        {
            _chrome.Quit();
        }

        [Test,Order(1)]
        public void WebDriver_GoToUrl_Google()
        {
            _chrome.Navigate().GoToUrl("http://www.google.com/");
            Assert.AreEqual(_chrome.Title,"Google");
        }

        [Test, Order(2)]
        public void WebDriver_GoToUrl_Wiki()
        {
            IWebElement search = _chrome.FindElement(By.Name("q"));
            search.SendKeys("unit testing");
            System.Threading.Thread.Sleep(250);
            search.SendKeys(Keys.Enter);
            IWebElement rso = _chrome.FindElement(By.Id("rso"));
            string t ="";
            foreach (IWebElement r in rso.FindElements(By.XPath("//*[@id=\"rso\"]/div")))
            {
                if (r.Text.Contains("https://en.wikipedia.org"))
                {
                    t = r.FindElement(By.CssSelector(" div > div.tF2Cxc > div.yuRUbf ")).GetAttribute("href");
                }
            }

            Assert.AreEqual(t, "https://en.wikipedia.org/wiki/Unit_testing");
            //Assert.AreEqual(_chrome.Title, "Unit testing - Wikipedia");
        }
    }
}