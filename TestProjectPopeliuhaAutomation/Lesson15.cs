using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

//using NUnit.Framework.Legacy;


namespace TestProjectPopeliuhaAutomation;

public class Lesson15
{
    public class TestClassLesson15
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestRegularAssert()
        {
            string textToInput = "ПРИВІТ!";
            IWebElement txtSearch = driver.FindElement(By.XPath("//input[@name='search']"));
            txtSearch.SendKeys("Привіт!");
            txtSearch.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(2000);

            IWebElement searchResults = driver.FindElement(By.XPath("//h1[@class='catalog_page__h1']"));
            string
                actualSearchText =
                    searchResults.Text.Split(' ')
                        [^1]; //тому що текст відображається не одразу, тому вказали індекс для пошуку слова з кінця, перше слово було б [0]. Отримана фраза це масив слів (перше слово 0 і так да)


            Assert.AreEqual(textToInput, actualSearchText,
                $"there is no search results {textToInput} on search results page"); //в кінці error message
            Assert.IsTrue(!string.IsNullOrEmpty(actualSearchText),
                $"actual search results is null or empty{textToInput} on search results page"); //результат false, АЛЕ Спочатку вказано "!"значить перевертається значення
            Assert.IsFalse(string.IsNullOrEmpty(actualSearchText),
                $"actual search results is null or empty{textToInput} on search results page");
            Assert.IsTrue(driver.Url.Contains("search"), $"url {driver.Url} does not contains search results");
            /*Assert.Pass();
             if (city_dropdown is enabled) {Assert.Pass()}
            Assert.Fail();
            if (modal window appeared) {Assert.Fail("message about reason of fail")}
            */
        }

        [Test]
        public void TestRegularAssertPart2_StringAssert()
        {
            StringAssert.Contains("tasha", "Natasha",
                "need to write error_message"); //спочтку "actual result", "expected result" 
            StringAssert.DoesNotContain("fala", "Natasha",
                "need to write error message"); //спочтку "actual result", "expected result" 
            StringAssert.AreEqualIgnoringCase("TAsHa", "Tasha",
                "need to write error_message"); ////спочтку "actual result", "expected result".Цей метод ігнорує регістр.Але значення повинні бути однаковими
            StringAssert.AreNotEqualIgnoringCase("TsssHa", "Tasha",
                "need to write error_message"); ////спочтку "actual result", "expected result".Цей метод ігнорує регістр.Але значення НЕ ПОВИННІ бути однаковими
            /// якщо вони однакові, тест впаде
            StringAssert.StartsWith("Na", "Natasha",
                "need to write error_message"); //спочтку "actual result", "expected result".Що один рядок починається з іншого
            StringAssert.StartsWith("M", "Natasha",
                "need to write error_message"); //спочтку "actual result", "expected result".Що один рядок НЕ ПОЧИНАЄТЬСЯ з іншого
            StringAssert.EndsWith("a", "Natasha",
                "need to write error_message"); //спочтку "actual result", "expected result".Що один рядок закінчується з іншого
            StringAssert.DoesNotEndWith("щ", "Natasha",
                "need to write error_message"); //спочтку "actual result", "expected result".Що один рядок НЕ ЗАКІНЧУЄТЬСЯ з іншого
            StringAssert.IsMatch("регулярний вираз", "регулярний вираз",
                "need to write error_message"); //Asserts that a string matches an expected regular expression pattern.
            StringAssert.DoesNotMatch("регулярний вираз", "регулярний вираз",
                "need to write error_message"); //Asserts that a string matches an expected regular expression pattern.
            
            
        }
        [Test]
        public void TestRegularAssertPart2_StringAssert_Multiple()
        {
            Assert.Multiple(() =>
            {
                StringAssert.Contains("tsha", "Natasha",
                    "need to write error_message");
                StringAssert.DoesNotContain("sha", "Natasha",
                    "need to write error message");
                StringAssert.AreEqualIgnoringCase("TAcHa", "Tasha",
                    "need to write error_message");
            });
        }

        [Test]
        public void TestRegularAssertPart2_CollectionAssert()
        {
            List<int> intListFirst = new List<int>() { 1, 5, 7, 9, 11 };
            List<int> intListSecond = new List<int>() { 1, 5, 7, 9, 11 };
            List<int> intListThird = new List<int>() { 1, 5, 7, 9, 11, 12, 13, 14 };
            List<int> intListFour = new List<int>() { 1, 5, 9, 7, 11, };
            List<int> intListFive = new List<int>();
            List<string> intListSix = new List<string>() { "a", "b", "c", "d" };
            CollectionAssert.AreEqual(intListFirst,
                intListSecond); //спочтку "actual result", "expected result".Тільки за умови що колекції однакові
            CollectionAssert.AreNotEqual(intListFirst,
                intListThird); //спочтку "actual result", "expected result".Тільки за умови що колекції однакові
            CollectionAssert.AreEquivalent(intListFirst, intListFour,
                "need to write error_message"); //спочтку "actual result", "expected result".Містять однакові елементи, але можуть бути в іншому порядку
            CollectionAssert.AreNotEquivalent(intListSecond, intListThird,
                "need to write error_message"); //спочтку "actual result", "expected result".НЕ Містять однакові елементи, не можуть бути в іншому порядку
            CollectionAssert.Contains(intListFirst, 5,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо що містить якийсь елемент
            CollectionAssert.DoesNotContain(intListFirst, 111,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо що НЕМІСТИТЬ якийсь елемент
            CollectionAssert.AllItemsAreInstancesOfType(intListFirst, typeof(int),
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо усі елементи колекції є int типу
            CollectionAssert.AllItemsAreNotNull(intListFirst,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо усі елементи колекції не є null
            CollectionAssert.IsNotEmpty(intListFirst,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо що колекція не порожня
            CollectionAssert.IsEmpty(intListFive,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо що колекція порожня
            CollectionAssert.AllItemsAreUnique(intListFirst,
                "need to write error_message"); //спочтку "actual result", "expected result". Перевіряємо що елементи в колекції унікальні (за умови без повторів)
            CollectionAssert.IsSubsetOf(intListSecond, intListThird,
                "need to write error_message"); //спочтку "actual result", "expected result".Supset означає що 1-а колекція містить усі елементи другої. Тільки в 2-ої додатково пара елементів
            CollectionAssert.IsSupersetOf(intListSecond, intListThird,
                "need to write error_message"); //спочтку "actual result", "expected result".Supset означає що 2-а колекція містить усі елементи першої. Тільки в 1-ої додатково пара елементів
            CollectionAssert.IsOrdered(intListFirst,
                "need to write error_message"); //перевірка на впорядкованість/ Відповідно за умови
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}