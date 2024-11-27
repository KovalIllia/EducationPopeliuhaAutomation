using System.Threading.Channels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectPopeliuhaAutomation;

public class Lesson14
{
    public class TestClassLesson14
    {
        [Test]
        public void TestRadioButton()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement radioButtonOther = driver.FindElement(By.XPath("//input[@value='other']"));
            IWebElement radioButtonMale = driver.FindElement(By.XPath("//input[@value='male']"));
            IWebElement radioButtonFemale = driver.FindElement(By.XPath("//input[@value='female']"));
            
            radioButtonFemale.Click();
            
            System.Threading.Thread.Sleep(3000);//в уроці цього немає, але без затримки буде некоректний результат
            bool isFemaleClicked = radioButtonFemale.Selected;//для того чи натиснутий був цей button
            bool isMalelicked = radioButtonMale.Selected;
            bool isOtherlicked = radioButtonOther.Selected;
            Console.WriteLine($"Female button:  {isFemaleClicked} ");
            Console.WriteLine($"Male button:  {isMalelicked} ");
            Console.WriteLine($"Other button:  {isOtherlicked} ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++");

            bool isMaleDisplayed = radioButtonMale.Displayed;
            bool isMaleEnabled = radioButtonMale.Enabled;
            Console.WriteLine($"Is male displayed: {isMaleDisplayed}");
            Console.WriteLine($"Is male enabled: {isMaleEnabled}");
            
            driver.Close(); 

        }

        [Test]
        public void TestCheckBox()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement checkBoxCar = driver.FindElement(By.XPath("//input[@value='Car']"));
            IWebElement checkBoxBike = driver.FindElement(By.XPath("//input[@value='Bike']"));
            bool checkBoxVirificationElementCar = checkBoxCar.Selected;
            bool checkBoxVirificationElementBike = checkBoxBike.Selected;

            Console.WriteLine($"element Car is checked: {checkBoxVirificationElementCar}");
            Console.WriteLine($"element Bike is checked: {checkBoxVirificationElementBike}");

            Console.WriteLine("=================================================");
            
            checkBoxCar.Click();
            checkBoxBike.Click();
            //System.Threading.Thread.Sleep(3000);
            checkBoxVirificationElementCar = checkBoxCar.Selected;
            checkBoxVirificationElementBike = checkBoxBike.Selected;

            Console.WriteLine($"element Car is checked: {checkBoxVirificationElementCar}");
            Console.WriteLine($"element Bike is checked: {checkBoxVirificationElementBike}");

            
        }

        [Test]
        public void TestDropdown()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");
            driver.Manage().Window.Maximize();

            IWebElement dropdownListVehicles = driver.FindElement(By.XPath("//select"));
            SelectElement _dropdownListVehicles = new SelectElement(dropdownListVehicles);//тому що створюємо новий елемент цього класу
            
            // Для того щоб можна було перемикати елементи в Дропдаун лісті--> ми звертаємо до елементу класу SelectElement
            var allSelectedOptions = _dropdownListVehicles.AllSelectedOptions.ToList();
            allSelectedOptions.ForEach(x=>Console.WriteLine("All selected options"+x.Text));//проходимо по всьому list
            
            bool isMultipleElements = _dropdownListVehicles.IsMultiple;
            Console.WriteLine($"is multiple: {isMultipleElements}");
            
            var optionalList = _dropdownListVehicles.Options.ToList();
            optionalList.ForEach(x=>Console.WriteLine($"optional list is :{x.Text}"));

            var wrappedElement = _dropdownListVehicles.WrappedElement;
            Console.WriteLine(wrappedElement);
            Console.WriteLine(wrappedElement.Text);
            Console.WriteLine($"tag name is: {wrappedElement.TagName}");
            
            _dropdownListVehicles.SelectByText("Volvo");
            var selectedOption = _dropdownListVehicles.SelectedOption.Text;
            Console.WriteLine($"First selected option: {selectedOption}");
            
            _dropdownListVehicles.SelectByText("Saab");
            var selectedOption2 = _dropdownListVehicles.SelectedOption.Text;
            Console.WriteLine($"Second selected option: {selectedOption2}");
            
            _dropdownListVehicles.SelectByIndex(3);
            var selectedOption3 = _dropdownListVehicles.SelectedOption.Text;
            Console.WriteLine($"Third selected option: {selectedOption3}");
            
            driver.Close();

        }
        
        [Test]
        public void TestUr()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");
            driver.Manage().Window.Maximize();

            IWebElement liTabFirst = driver.FindElement(By.XPath("//li[contains(@class,'et_pb_tab_0')]"));
            IWebElement liTabSecond = driver.FindElement(By.XPath("//li[contains(@class,'et_pb_tab_1')]"));
            IWebElement displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style,'none'))]/div[@class='et_pb_tab_content']"));

            Console.WriteLine($"displayed option: {displayedOption.Text} ");
            
            
            liTabSecond.Click();
            Thread.Sleep(3000);
            displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style,'none'))]/div[@class='et_pb_tab_content']"));
            Console.WriteLine($"displayed option: {displayedOption.Text} ");
            
            
            liTabFirst.Click();
            Thread.Sleep(3000);// не дуже правильний синтаксис затримки. Але вона потірбна щось зачекати щоб полде змінювало значення
            displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style,'none'))]/div[@class='et_pb_tab_content']"));
            Console.WriteLine($"displayed option: {displayedOption.Text} ");
            
            
            driver.Close();
        }
        
    }
}