using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeSelenium
{
    internal class RegisterFail
    {

        public class UnsuccessfulRegisterTesting
        {

            IWebDriver driver = new ChromeDriver();

            //[Test]
            public void UnuccessfulRegisterTest()
            {
                // Arrange 
                string displayName = "user";
                string username = "user"; // must be changed on each test run
                string email = "user@gmail.com"; // must be changed on each test run
                string password = "12345678";

                // Act
                driver.Navigate().GoToUrl("http://localhost:3000");
                driver.FindElement(By.Id("openRegister")).Click();
                driver.FindElement(By.Name("displayName")).SendKeys(displayName);
                driver.FindElement(By.Name("username")).SendKeys(username);
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.Id("register")).Click();

                // Assert
                string expectedUrl = "http://localhost:3000/activities";
                Assert.AreEqual(expectedUrl, driver.Url);
            }
        }

    }
}
