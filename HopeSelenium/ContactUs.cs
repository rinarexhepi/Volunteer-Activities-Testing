using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeSelenium
{
    internal class ContactUs
    {

        public class ContactUsTesting
        {

            IWebDriver driver = new ChromeDriver();

           // [Test]
            public void ContactUs()
            {
              
                string name = "test";
                string surname = "test";
                string mail = "test";
                string number = "123"; //MMMM d, yyyy h:mm aa
                string description = "hello hello hello";
                string email = "poema@gmail.com";
                string password = "Pa$$w0rd";

            
                driver.Navigate().GoToUrl("http://localhost:3000");

                driver.FindElement(By.Id("openLogin")).Click();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.Id("login")).Click();
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement createMessageButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("createMessage")));

                createMessageButton.Click();

                driver.FindElement(By.Name("name")).SendKeys(name);
                driver.FindElement(By.Name("surname")).SendKeys(surname);
                driver.FindElement(By.Name("email")).SendKeys(mail);
                driver.FindElement(By.Name("number")).SendKeys(number);
                driver.FindElement(By.Id("messageDescription")).SendKeys(description);
                driver.FindElement(By.Id("submitMessage")).Click();


/*                string actualUrl = driver.Url;
                string expectedUrl = "http://localhost:3000/messages/";
                string messageId = actualUrl.Replace(expectedUrl, string.Empty); // Extract the ID from the URL

                Assert.IsTrue(!string.IsNullOrEmpty(messageId)); // Verify that the ID is not empty

                string expectedUrlWithId = $"http://localhost:3000/messages/{messageId}"; // Construct the expected URL with the ID
                Assert.AreEqual(expectedUrlWithId, driver.Url);*/
            }

        }
    }
}
