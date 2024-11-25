using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation
{
    public class TestClassLesson8
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit(); // Закриває браузер і всі пов'язані процеси
        }

        [Test]
        public void TestByCssSelector()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.CssSelector("#search-input"));
            string text = element.Text;

        }
        
        [Test]
        public void TestById()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.Id("search"));
            string text = element.Text;

        }
        [Test]
        public void TestByName()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.Name("search_query"));
            string text = element.Text;

        }
        [Test]
        public void TestByTitle()//про цей тест в відосі кажуть LinkText але я шукаю по tittle (так він назначений на сторінці)
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.LinkText("YouTube Premium"));
            string text = element.Text;

        }
        [Test]
        public void TestByLinkText()
        {
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/link.html");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.LinkText("click here"));
            string text = element.GetAttribute("href");

        }
        [Test]
        public void TestByPartialLinkText()
        {
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/accessing-link.html");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.PartialLinkText("go"));
            string text = element.GetAttribute("href");

        }
        [Test]
        public void TestByTagName()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.TagName("h1"));
            //string text = element.GetAttribute("href"); не перевіряю тому що елемент невидимий

        }
        [Test]
        public void TestByXPath()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            var element = driver.FindElement(By.XPath("//*[@id=\"search\"]"));
            string text = element.GetAttribute("text");
            

        }
        
        

        
    }
}