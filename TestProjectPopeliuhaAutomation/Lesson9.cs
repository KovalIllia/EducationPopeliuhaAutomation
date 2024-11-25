using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation;

public class TestClassLesson9 ()
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
    
    
    
}