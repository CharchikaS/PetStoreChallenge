using NUnit.Framework;
using PetStoreChallenge.Extensions;
using PetStoreChallenge.Models;
using System;
using TechTalk.SpecFlow;

namespace PetStoreChallenge.StepDefinitions
{
    [Binding]
    public class OrderStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public OrderStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I login successfully")]
        public void GivenILoginSuccessfully()
        {
            Users user = _scenarioContext.GetUser();
            user.SendLoginRequest(user.Username, user.Password);
        }

        [When(@"I place an order for a pet")]
        public void WhenIPlaceAnOrderForAPet()
        {
            Orders newOrder = new Orders();
            var response = newOrder.SendorderCreationRequest();
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
        }

        [Then(@"the order should be placed successfully")]
        public void ThenTheOrderShouldBePlacedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
