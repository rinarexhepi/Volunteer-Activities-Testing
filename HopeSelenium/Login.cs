using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HopeSelenium
{
    internal class Login
    {
        public class LogInTesting
        {

            IWebDriver driver = new ChromeDriver();

          //[Test]
            public void SuccessfulLoginTest()
            {
                // Arrange
                string email = "poema@gmail.com";
                string password = "Pa$$w0rd";

                // Act
                driver.Navigate().GoToUrl("http://localhost:3000");
                driver.FindElement(By.Id("openLogin")).Click();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.Id("login")).Click();

                // Assert
                string expectedUrl = "http://localhost:3000/activities";
                Assert.AreEqual(expectedUrl, driver.Url);
            }

          
            


        }
    }
}