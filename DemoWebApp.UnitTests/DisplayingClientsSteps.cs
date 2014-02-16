using System;
using TechTalk.SpecFlow;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class DisplayingClientsSteps
    {
        [Given(@"That I have two clients defined")]
public void GivenThatIHaveTwoClientsDefined()
{
    ScenarioContext.Current.Pending();
}

        [When(@"I load the page")]
public void WhenILoadThePage()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"two clients should be displayed on the screen")]
public void ThenTwoClientsShouldBeDisplayedOnTheScreen()
{
    ScenarioContext.Current.Pending();
}
    }
}
