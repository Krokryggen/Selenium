using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace IteraCase
{
 
    [TestClass]
    public class OnlineShop
    {
        IWebDriver driver = new ChromeDriver();
              
        public void Setup()
        {
            driver.Manage().Window.Maximize();          
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
        }

        public void TearDown()
        {
            driver.Quit();
        }

        public void Login()
        {
            string userName = "Kaurin";
            string password = "12345";

            Setup();
            driver.FindElement(By.CssSelector("#login2")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector("#loginusername")).SendKeys(userName);
            driver.FindElement(By.CssSelector("#loginpassword")).SendKeys(password);
            driver.FindElement(By.CssSelector("#logInModal > div > div > div.modal-footer > button.btn.btn-primary")).Click();

            Thread.Sleep(2000);
        }

        public void AcceptAlert()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void CreateAccount()
        {
            string newUserName = "Kaurin444";
            string newPassword = "12345";

            Setup();                   

            driver.FindElement(By.CssSelector("#signin2")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#sign-password")));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#sign-username")).SendKeys(newUserName);
            driver.FindElement(By.CssSelector("#sign-password")).SendKeys(newPassword);
            driver.FindElement(By.CssSelector("#signInModal > div > div > div.modal-footer > button.btn.btn-primary")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(driver => driver.SwitchTo().Alert().Text);
            
            string successMessage = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
                   
            TearDown();
            Assert.AreEqual(successMessage, ("Sign up successful."));

        }

         
       

        [TestMethod]
        public void PlaceOrder()
        {
            Login();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#nameofuser")));
            string nameOfUser = driver.FindElement(By.CssSelector("#nameofuser")).Text;
            Assert.AreEqual(nameOfUser, "Welcome Kaurin");

            driver.FindElement(By.CssSelector("#navbarExample > ul > li.nav-item.active > a")).Click();
            driver.FindElement(By.XPath("//a[contains(text(), 'Phones')]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")));
            driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")).Click();
            driver.FindElement(By.CssSelector("#tbodyid > div.row > div > a")).Click();
            AcceptAlert();

            driver.FindElement(By.CssSelector("#navbarExample > ul > li.nav-item.active > a")).Click();
            driver.FindElement(By.XPath("//a[contains(text(), 'Laptops')]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")).Click();
            driver.FindElement(By.CssSelector("#tbodyid > div.row > div > a")).Click();
            AcceptAlert();

            driver.FindElement(By.CssSelector("#navbarExample > ul > li.nav-item.active > a")).Click();
            driver.FindElement(By.XPath("//a[contains(text(), 'Monitors')]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#tbodyid > div:nth-child(1) > div > div > h4 > a")).Click();
            driver.FindElement(By.CssSelector("#tbodyid > div.row > div > a")).Click();
            AcceptAlert();

            driver.FindElement(By.CssSelector("#cartur")).Click();
            driver.FindElement(By.CssSelector("#page-wrapper > div > div.col-lg-1 > button")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(By.CssSelector("#name")));

            driver.FindElement(By.CssSelector("#name")).SendKeys("Marius");
            driver.FindElement(By.CssSelector("#country")).SendKeys("Norge");
            driver.FindElement(By.CssSelector("#city")).SendKeys("Oslo");
            driver.FindElement(By.CssSelector("#card")).SendKeys("4444 4444 4444 4444");
            driver.FindElement(By.CssSelector("#month")).SendKeys("June");
            driver.FindElement(By.CssSelector("#year")).SendKeys("1996");
            driver.FindElement(By.CssSelector("#orderModal > div > div > div.modal-footer > button.btn.btn-primary")).Click();

            string purchaseConfirmed = driver.FindElement(By.CssSelector("body > div.sweet-alert.showSweetAlert.visible > h2")).Text;

            driver.FindElement(By.CssSelector("body > div.sweet-alert.showSweetAlert.visible > div.sa-button-container > div > button")).Click();

            TearDown();

            Assert.AreEqual(purchaseConfirmed, "Thank you for your purchase!");

        }

     }  

}
