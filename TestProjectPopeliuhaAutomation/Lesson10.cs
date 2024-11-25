using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectPopeliuhaAutomation;

public class Lesson10
{
    class TestClassLesson10
    {
        [Test]
        public void SearchListOfElements()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            List<IWebElement> products = driver.FindElements(By.XPath("//div[@class='products__item']//div[@class='products__item_caption']")).ToList();//якщо в кінці не конвертувати значення, відобр помилка
            //так як в нас list відповідно викорис foreach
            foreach (IWebElement product in products)
            {
                //тут звернення не до driver.FindElement а до вже існуючого елемента product в list products 
                IWebElement productName = product.FindElement(By.XPath("./a"));//указали лише //a тому що основна частина XPath вказана вище в driver.FindElements
                //string _productName = productName.GetAttribute("title"); це альтернатива коду на 25 рядку
                string _productName = productName.Text;//отримуємо назву title, який в ложеності тегу ./a

                List<IWebElement> elementPricesList = product.FindElements(By.XPath(".//div[contains(@class,'products__item_price')]")).ToList();//це означає ".//" -> будь які елементи(а не елемент одразу після знайденого елемента)
                
                //відсіюємо ті, що мають слово "old" або "wrapper" в назві класу
                IWebElement correctPrice=null;
                foreach (var elementPrice in elementPricesList)
                {
                    string elementPriceClass = elementPrice.GetAttribute("class");
                    if (!elementPriceClass.Contains("old") && !elementPriceClass.Contains("wrapper"))//(elementPriceClass.Contains("old") || elementPriceClass.Contains("wrapper"))
                    {
                        correctPrice = elementPrice;
                    }
                }

                if (correctPrice == null)
                {
                    throw new AssertionException($"There is no correct price for product {_productName}");
                }

                string _correctPrice = correctPrice.Text;
                Console.WriteLine($"name of product - {_productName}");
                Console.WriteLine($"price of product - {_correctPrice}");

            }
        }
    }
}