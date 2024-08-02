using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PetStoreChallenge.Extensions;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace PetStoreChallenge.StepDefinitions
{
    [Binding]
    public class AccountCreationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public AccountCreationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I register as a new User on Pet Store")]
        [Given(@"I am a new user")]
        public void GivenIAmANewUser()
        {
            Users newUser = new Users();
            newUser.InitializeNewUser();
            _scenarioContext.SetUser(newUser);            
        }

        [When(@"I request creation of a new account with username (.*)")]
        public void WhenIRequestCreationOfANewAccountWithUsername(string userName )
        {
            _scenarioContext.SetUserName(userName);
        }

        [When(@"with firstname (.*) and lastname (.*)")]
        public void WhenWithFirstnameFirstnameAndLastnameLastname(string firstname, string lastname)
        {
            _scenarioContext.SetFirstName(firstname);
            _scenarioContext.SetLastName(lastname);
        }

        [When(@"with email id (.*)")]
        public void WhenWithEmailId(string emailId)
        {
            _scenarioContext.SetEmailId(emailId);
        }

        [When(@"with password (.*)")]
        public void WhenWithPassword(string password)
        {
            _scenarioContext.SetPassword(password);
        }

        [When(@"with phone number (.*)")]
        public void WhenWithPhoneNumber(string phone)
        {
            _scenarioContext.SetPhone(phone);
        }

        [When(@"I send the User Creation request")]
        public void WhenISendTheUserCreationRequest()
        {
            Users newUser = _scenarioContext.GetUser();
            newUser.AddFirstName(_scenarioContext.GetFirstName());
            newUser.AddLastName(_scenarioContext.GetLastName());
            newUser.AddUserName(_scenarioContext.GetUserName());
            newUser.AddEmail(_scenarioContext.GetEmailId());
            newUser.AddPassword(_scenarioContext.GetPassword());
            newUser.AddPhone(_scenarioContext.GetPhone());

            var response = newUser.SendUserCreationRequest();
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
        }

        [Then(@"this new user account should be created successfully")]
        public void ThenThisNewUserAccountShouldBeCreatedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
        [When(@"I request creation of new users")]
        public void WhenIRequestCreationOfNewUsers()
        {
            List<Users> NewUsersList = _scenarioContext.GetUser().CreateBulkNewUsersList();
            Console.WriteLine($"number of new users to be created: {NewUsersList.Count}");
            _scenarioContext.SetBulkUsersList(NewUsersList);
        }

        [When(@"I send the bulk User Creation request (.*)")]
        public void WhenISendTheBulkUserCreationRequest(string requestType)
        {
            List<Users> NewUsersList = _scenarioContext.GetBulkUsersList();
            var response = NewUsersList.SendBulkUsersCreationRequest(requestType);
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
        }

        [Then(@"these new users accounts should be created successfully")]
        public void ThenTheseNewUserAccountShouldBeCreatedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


    }
}
