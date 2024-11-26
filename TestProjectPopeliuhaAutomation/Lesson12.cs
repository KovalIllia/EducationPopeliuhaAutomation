using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation;

public class Lesson12
{
    class TestClassLesson12
    {
        [Test]
        public void TestKeyClass()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/");

            IWebElement txtSearchField = driver.FindElement(By.XPath("//input[@name='search']"));
            // txtSearchField.SendKeys("Привіт!");
            // txtSearchField.SendKeys(Keys.Backspace);
            // txtSearchField.SendKeys(Keys.Enter);
            txtSearchField.SendKeys(Keys.Shift+"a");

        }
    }
}