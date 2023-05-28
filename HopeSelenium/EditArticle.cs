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
    internal class EditArticle
    {

        public class EditArticleTesting
        {

            IWebDriver driver = new ChromeDriver();

         [Test]
            public void EditArticle()
            {
                
                string articleDetails = " - Updated article title";
                string email = "poema@gmail.com";
                string password = "Pa$$w0rd";

                driver.Navigate().GoToUrl("http://localhost:3000");
                driver.FindElement(By.Id("openLogin")).Click();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.Id("login")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement editArticlesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("articleSs")));
                editArticlesButton.Click();


                IWebElement chooseArticleButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("fotojaArtikullit")));
                chooseArticleButton.Click();


                IWebElement editArticleButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("editArticle")));
                editArticleButton.Click();

                driver.FindElement(By.Name("articleTitle")).SendKeys(articleDetails);
                IWebElement saveArticleButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("saveArticle")));
                saveArticleButton.Click();
               
                string actualUrl = driver.Url;
                string expectedUrl = "http://localhost:3000/articles/";
                string articleIs = actualUrl.Replace(expectedUrl, string.Empty); // Extract the ID from the URL

                Assert.IsTrue(!string.IsNullOrEmpty(articleIs)); // Verify that the ID is not empty

                string expectedUrlWithId = $"http://localhost:3000/articles/{articleIs}"; // Construct the expected URL with the ID
                Assert.AreEqual(expectedUrlWithId, driver.Url);
            }

        }
    }
}
