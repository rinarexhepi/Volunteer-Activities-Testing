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
    internal class JoinActivity
    {

        public class JoinActivityTesting
        {

            IWebDriver driver = new ChromeDriver();

            //[Test]
            public void JoinActivity()
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

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement editArticlesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("viewActivity")));
                editArticlesButton.Click();

                IWebElement joinActivityButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("JoinButton")));
                joinActivityButton.Click();

                // Assert
                string actualUrl = driver.Url;
                string expectedUrl = "http://localhost:3000/activities/";
                string activityId = actualUrl.Replace(expectedUrl, string.Empty); // Extract the ID from the URL

                Assert.IsTrue(!string.IsNullOrEmpty(activityId)); // Verify that the ID is not empty

                string expectedUrlWithId = $"https://example.com/activities/{activityId}"; // Construct the expected URL with the ID
                Assert.AreEqual(expectedUrlWithId, driver.Url);
            }

        }
    }
}
