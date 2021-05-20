using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LocatingElements
{
    internal class Program
    {
        public static string BASE_URL { get; set; } = "https://www.trendyol.com/uyelik";
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BASE_URL);
            driver.WaitForPageLoad();

            try
            {
                IWebElement mail = driver.FindElement(By.XPath("//input[@id='register-email']"));
                IWebElement password = driver.FindElement(By.XPath("//input[@id='register-password-input']"));
                IWebElement registerBtn = driver.FindElement(By.XPath("//button[@type='submit']"));

                if (mail == null & password == null & registerBtn == null)
                {
                    throw new Exception("CANNOT_FOUND_PAGE");
                }
                
                mail.SendKeys("YTSelenium@gmail.com");
                password.SendKeys("YTSelenium2021");
                registerBtn.Click();
                
                Thread.Sleep(TimeSpan.FromSeconds(2));
                
                driver.WaitForPageLoad();

                Console.WriteLine("Hesap oluşturulması tamamlandı.");
                
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        
        
    }

    public static class Extensions
    {
        public static void WaitForPageLoad(this IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) driver;
                WebDriverWait webDriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
                webDriverWait.Until<bool>((IWebDriver x) => javaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
               
            }
        }
    }
}