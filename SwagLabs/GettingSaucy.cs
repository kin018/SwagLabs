using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace SwagLabs
{
    [TestClass]
    public class GettingSaucy
    {
        IWebDriver driver;
        string USERNAME = "performance_glitch_user";
        string PASSWORD = "secret_sauce";
        string FIRSTNAME = "AUTOMATED";
        string LASTNAME = "TEST";
        string ZIPCODE = "07111";
        string SWAG = "Congrats! You have successfully logged in...sorted porducts from cheapest to most expensive...selected items to purchase...checkout...fill shipping form...finish...and logged out";
        string OOPS = "Not Quite...Try Again";
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        }

        [TestCleanup]
        public void CleanUP()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GettingSaucyTestMethod()
        {
            IWebElement _username = driver.FindElement(By.CssSelector("#user-name"));
            _username.SendKeys(USERNAME); //locates username field and inputs USERNAME string 

            IWebElement _password = driver.FindElement(By.CssSelector("#password"));
            _password.SendKeys(PASSWORD); //locates password field and inputs PASSWORD string 

            IWebElement loginBTN = driver.FindElement(By.CssSelector("#login-button"));
            loginBTN.Click();//clicks login button 
            Assert.IsTrue(driver.Url.Contains("https://www.saucedemo.com/inventory.html"));//Asserts that login authentication has passed 

            IWebElement sortProductContainer = driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select"));
            sortProductContainer.Click();//selects sort field 

            IWebElement lohi = driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > div.right_component > span > select > option:nth-child(3)"));
            sortProductContainer.Click();//selects sort by lowest to highest price 

            IWebElement sauceLabsBackpackAddToCart = driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));
            sauceLabsBackpackAddToCart.Click();//adds item to cart

            IWebElement sauceLabsOnesieAddToCart = driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-onesie"));
            sauceLabsOnesieAddToCart.Click();//adds item to cart

            IWebElement shoppingCartBTN = driver.FindElement(By.CssSelector("#shopping_cart_container > a"));
            shoppingCartBTN.Click();//clicks shopping cart button

            IWebElement checkoutBTN = driver.FindElement(By.CssSelector("#checkout"));
            checkoutBTN.Click();//clicks checkout button

            IWebElement _firstname = driver.FindElement(By.CssSelector("#first-name"));
            _firstname.SendKeys(FIRSTNAME);//locates firstname field and inputs FIRSTNAME string 

            IWebElement _lastname = driver.FindElement(By.CssSelector("#last-name"));
            _lastname.SendKeys(LASTNAME);

            IWebElement _zipcode = driver.FindElement(By.CssSelector("#postal-code"));
            _zipcode.SendKeys(ZIPCODE);

            IWebElement continueBTN = driver.FindElement(By.CssSelector("#continue"));
            continueBTN.Click();//clicks continue button

            IWebElement finishBTN = driver.FindElement(By.CssSelector("#finish"));
            finishBTN.Click();

            IWebElement backHomeBTN = driver.FindElement(By.CssSelector("#back-to-products"));
            backHomeBTN.Click();

            IWebElement menuBurgerBTN = driver.FindElement(By.CssSelector("#react-burger-menu-btn"));
            menuBurgerBTN.Click();//clicks react burge menu

            IWebElement logout = driver.FindElement(By.CssSelector("#logout_sidebar_link"));
            menuBurgerBTN.Click();//clicks logout
            Assert.IsTrue(driver.Url.Contains("https://www.saucedemo.com/"));//Assertion that we are back in landing page 
            if (driver.Url.Contains("https://www.saucedemo.com/")) //if this statement is true, console will display message 
            {
                Console.WriteLine(SWAG);
            }
            else
            {
                Console.WriteLine(OOPS);

            }            
        }
    }
}
