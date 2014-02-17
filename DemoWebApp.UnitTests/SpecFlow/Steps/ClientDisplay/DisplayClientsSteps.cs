using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class ClientDataDisplayedSteps
    {
        private DemoWebAppPage demoPage;
        private IWebDriver driver;

        [BeforeScenario()]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [AfterScenario()]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"That I have two clients defined")]
        public void GivenThatIHaveTwoClientsDefined()
        {
            Model2.Client client1 = new Model2.Client();
            Model2.Client client2 = new Model2.Client();
        }
            
        [When(@"I load the page")]
        public void WhenILoadThePage()
        {
            demoPage = DemoWebAppPage.NavigateTo(driver);
        }

        [Then(@"two clients should have names, addresses, and accounts")]
        public void ThenTwoClientsShouldBeDisplayedOnTheScreen()
        {
            var results = driver.FindElements(By.ClassName("col-md-4"));
            Assert.IsTrue(results.Count == 2);
            Assert.IsTrue(results[0].FindElement(By.TagName("h2")).Text == "Client #1");
            Assert.IsTrue(results[1].FindElement(By.TagName("h2")).Text == "Client #2");
            Assert.IsTrue(results[0].FindElements(By.TagName("p"))[1].FindElement(By.TagName("span")).Text == "123 Test St., Testington, NJ 08615");
            Assert.IsTrue(results[1].FindElements(By.TagName("p"))[1].FindElement(By.TagName("span")).Text == "453 Test St., Testington, NJ 08615");
            Assert.IsTrue(results[0].FindElement(By.TagName("ul")).FindElements(By.TagName("li")).Count == 2);
            Assert.IsTrue(results[1].FindElement(By.TagName("ul")).FindElements(By.TagName("li")).Count == 2);
        }
    }
}
