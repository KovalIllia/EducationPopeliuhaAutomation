using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation;

public class Lesson13
{
    class TestClassLesson13
    {
        [Test]
        public void TestGetAttributeAndText_FromElementOnPage()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtHeader = driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]/main/div/div[2]/div/div[1]/div/div[3]/a"));
            string headerText = txtHeader.Text;
            Console.WriteLine($"headerText is : {headerText}");
            string headerClass = txtHeader.GetAttribute("class");//якщо невірно вказати назву атрибуту-- помилки не буде, буде пустий вивід
            Console.WriteLine($"headerClass is : {headerClass}");
            
            driver.Close();

            // IWebElement searchTitle =
            //     driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]/main/div/div[2]/div/div[1]/div/div[3]/a"));
            // string searchTestTitle = searchTitle.GetAttribute("title");
            // Console.WriteLine($"i search : {searchTestTitle}");
        }
    }

}