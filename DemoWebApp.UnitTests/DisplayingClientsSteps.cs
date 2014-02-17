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
    public class DisplayingClientsSteps
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

        [Then(@"two clients should be displayed on the screen")]
        public void ThenTwoClientsShouldBeDisplayedOnTheScreen()
        {
            var results = driver.FindElements(By.ClassName("col-md-4"));
            Assert.IsTrue(results.Count == 2);
        }
    }
}
