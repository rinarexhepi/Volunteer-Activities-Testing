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
    internal class CreateActivity
    {

        public class CreateActivityTesting
        {

            IWebDriver driver = new ChromeDriver();

           //[Test]
            public void CreateActivity()
            {
        
                string title = "test";
                string description = "test";
                string category = "Culture";
                string date = "May 26,2023, 05:00 pm"; //MMMM d, yyyy h:mm aa
                string city = "test";
                string venue = "test";
                string email = "poema@gmail.com";
                string password = "Pa$$w0rd";

         
                driver.Navigate().GoToUrl("http://localhost:3000");
                driver.FindElement(By.Id("openLogin")).Click();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.Id("login")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement createActivityButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("createActivity")));
                createActivityButton.Click();

                driver.FindElement(By.Id("titleOfActivity")).SendKeys(title);
                driver.FindElement(By.Id("descriptionOfActivity")).SendKeys(description);

                IWebElement categoryDropdown = driver.FindElement(By.Id("categoryOfActivity"));
                SelectElement categorySelect = new SelectElement(categoryDropdown);
                categorySelect.SelectByText(category);

                driver.FindElement(By.Id("dateOfActivity")).SendKeys(date);
                driver.FindElement(By.Id("cityOfActivity")).SendKeys(city);
                driver.FindElement(By.Id("venueOfActivity")).SendKeys(venue);
                driver.FindElement(By.Id("createActivity")).Click();

                // Assert
                string actualUrl = driver.Url;
                string expectedUrl = "http://localhost:3000/activities/";
                string activityId = actualUrl.Replace(expectedUrl, string.Empty); // Extract the ID from the URL

                Assert.IsTrue(!string.IsNullOrEmpty(activityId)); // Verify that the ID is not empty

                string expectedUrlWithId = $"http://localhost:3000/activities/{activityId}"; // Construct the expected URL with the ID
                Assert.AreEqual(expectedUrlWithId, driver.Url);
            }

        }
    }
}
