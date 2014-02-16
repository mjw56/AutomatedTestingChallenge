using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class DemoWebAppPage
    {
        private static IWebDriver driver;

        public static DemoWebAppPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl("http://localhost:9098/Default.aspx");
            var page = new DemoWebAppPage();
            PageFactory.InitElements(driver, page);
            return page;
        }
    }
}
