using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoWebApp.Model2;
using System.Collections.Generic;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class AccountObjectFeatureSteps
    {
        Account account;

        [Given(@"I have Account constructor with params")]
        public void GivenIHaveAClientConstructorWithParams()
        {

        }

        [When(@"I call the Account constructor")]
        public void WhenICallTheAccountConstructor()
        {
            account = new Account("12345", "checking", 1234.56m, DateTime.Now);
        }

        [Then(@"it should return a new Account object")]
        public void ThenItShouldReturnANewAccountObject()
        {
            Assert.IsTrue(account.AccountNumber == "12345");
            Assert.IsTrue(account.Type == "checking");
            Assert.IsTrue(account.Balance == 1234.56m);
        }
    }
}
