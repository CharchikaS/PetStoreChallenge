using NUnit.Framework;
using PetStoreChallenge.Extensions;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using System;
using TechTalk.SpecFlow;

namespace PetStoreChallenge.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am an unregistered user of Pet Store")]
        [Given(@"I am a registered user of Pet Store")]
        public void GivenIAmARegisteredUserOfPetStore()
        {
            //code to get user may be added
        }

        [When(@"I enter username (.*)")]
        public void WhenIEnterUsername(string username)
        {
            _scenarioContext.SetUserName(username);
        }

        [When(@"password (.*)")]
        public void WhenPassword(string password)
        {
            _scenarioContext.SetPassword(password);
        }

        [When(@"I send the Login request")]
        public void WhenISendTheLoginRequest()
        {
            var response = _scenarioContext.GetUser().SendLoginRequest(_scenarioContext.GetUserName(), _scenarioContext.GetPassword());
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [When(@"I enter random username")]
        public void WhenIEnterRandomUsername()
        {
            _scenarioContext.SetUserName(TestContext.CurrentContext.Random.GetString());
        }

        [When(@"random password <Password>")]
        public void WhenRandomPasswordPassword()
        {
            _scenarioContext.SetPassword(TestContext.CurrentContext.Random.GetString());
        }

        [Then(@"login should be unsuccessful")]
        public void ThenLoginShouldBeUnsuccessful()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
