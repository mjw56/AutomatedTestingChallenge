using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoWebApp.Model2;
using System.Collections.Generic;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class ClientObjectFeatureSteps
    {
        Client client;
        
        public class Client
        {
            public long Id { get; set; }
            public string Key { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public virtual List<Account> Accounts { get; set; }
            public DateTime CreatedOn { get; set; }

            public Client()
            {
                CreatedOn = DateTime.Now;
            }

            public Client(long id, string key, string name, string address, List<Account> accounts, DateTime created)
            {
                this.Id = id;
                this.Key = key;
                this.Name = name;
                this.Address = address;
                this.Accounts = accounts;
                this.CreatedOn = created;
            }
        }

        [Given(@"I have a client constructor with params")]
        public void GivenIHaveAClientConstructorWithParams()
        {
            
        }

        [When(@"I call the constructor")]
        public void WhenICallTheConstructor()
        {
            List<Account> accountList = new List<Account>();
            client = new Client(1, "12345", "Test Client", "123 Test Drive Testingon, NJ 03456", accountList, DateTime.Now);
        }

        [Then(@"it should return a new Client object")]
        public void ThenItShouldReturnANewClientObject()
        {
            Assert.IsTrue(client.Id == 1);
            Assert.IsTrue(client.Key == "12345");
            Assert.IsTrue(client.Name == "Test Client");
            Assert.IsTrue(client.Address == "123 Test Drive Testingon, NJ 03456");
        }
    }
}
