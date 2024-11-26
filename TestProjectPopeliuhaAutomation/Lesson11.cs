using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation;

public class Lesson11
{
    class TestClassLesson11
    {
        [Test]
        public void TestFilter_ForUser_WithClickAndSendKeys()
        {
            string mobileModel = "Apple";
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtFilterForUser =
                driver.FindElement(By.XPath(
                    "//*[text()='Виробники']/../following-sibling::div[@class='filter-category__search']//input"));
            txtFilterForUser.SendKeys(mobileModel);//"Apple"--введений текст, або використ змінну якщо є
            System.Threading.Thread.Sleep(3000);//простенький weiter (в тестах такий не використ.але ті,що потрібні в темах далі)
            IWebElement checkBoxByMobileModel = driver.FindElement(By.XPath($"//span[text()='{mobileModel}']/parent::span"));//альтернатива знегерована автомат /html/body/div[4]/div/div[1]/aside/div[1]/div[1]/div[3]/div[1]/div/div[3]/div[1]/label[2]/span
            checkBoxByMobileModel.Click();
            
            //Assert --> буде вивчатись далі


        }
    }
}