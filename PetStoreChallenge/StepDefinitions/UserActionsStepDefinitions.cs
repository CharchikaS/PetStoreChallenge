using NUnit.Framework;
using PetStoreChallenge.Extensions;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using System;
using TechTalk.SpecFlow;

namespace PetStoreChallenge.StepDefinitions
{
    [Binding]
    public class UserActionsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public UserActionsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am an admin user of Pet Store")]
        public void GivenIAmAnAdminUserOfPetStore()
        {
            Users AdminUser = new Users();
            AdminUser.InitializeNewUser();
            _scenarioContext.SetUserName(AdminUser.Username);
            Console.WriteLine($"Username: {AdminUser.Username}");
            _scenarioContext.SetUser(AdminUser);
            //create user
            var response = AdminUser.SendUserCreationRequest();
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
        }

        [When(@"I enter valid username (.*)")]
        public void WhenIEnterValidUsername(string username)
        {
            _scenarioContext.SetUserName(username);
        }

        [When(@"I send the get request")]
        public void WhenISendTheGetRequest()
        {
            var response = _scenarioContext.GetUser().SendGetUserDetailsRequest(_scenarioContext.GetUserName());
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
            APIRequestDriver driver = new APIRequestDriver();
            _scenarioContext.SetResponseContent(driver.GetResponseContent<Users>(response));
        }

        [Then(@"I should get all the details of this user")]
        public void ThenIShouldGetAllTheDetailsOfThisUser()
        {
            var userDetails = _scenarioContext.GetResponseContent();
            Assert.IsNotNull(userDetails);
            Console.WriteLine(userDetails);
            Console.WriteLine($"Response Userdetails - Username: {userDetails.Username}");
            userDetails.Username.Should().Be(_scenarioContext.GetUserName());
            //Validations for other fields like firstname lastname can be added as well
        }

        [When(@"I enter updated (.*)")]
        public void WhenIEnterUpdated(string emailId)
        {
            var user = FetchUserDetails(_scenarioContext.GetUserName());
            Console.WriteLine($"emailId before update: {user.Email}");
            _scenarioContext.SetEmailId(emailId);

            //update email id in user record
            user.AddEmail(emailId);
            _scenarioContext.SetUser(user);
        }

        [When(@"I send the update request")]
        public void WhenISendTheUpdateRequest()
        {
            var response = _scenarioContext.GetUser().SendUpdateUserDetailsRequest(_scenarioContext.GetUserName());
            Assert.IsNotNull(response);
            Console.WriteLine(response.StatusCode);
        }

        [Then(@"update of email should be successful")]
        public void ThenUpdateOfEmailShouldBeSuccessful()
        {
            var user = FetchUserDetails(_scenarioContext.GetUserName());
            Console.WriteLine($"emailId after update: {user.Email}");
            user.Email.Should().Be(_scenarioContext.GetEmailId());
        }

        [When(@"I send the delete request")]
        public void WhenISendTheDeleteRequest()
        {
            var response = _scenarioContext.GetUser().SendDeleteUserDetailsRequest(_scenarioContext.GetUserName());
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Console.WriteLine(response.StatusCode);
        }

        [Then(@"this user should be deleted successfully")]
        public void ThenThisUserShouldBeDeletedSuccessfully()
        {
            var response = _scenarioContext.GetUser().SendDeleteUserDetailsRequest(_scenarioContext.GetUserName());
            Assert.IsNotNull(response);
            Console.WriteLine(response.StatusCode);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
        public Users FetchUserDetails(string username)
        {
            APIRequestDriver driver = new APIRequestDriver();
            Console.WriteLine($"fetching user details for username: {username}");
            var response = _scenarioContext.GetUser().SendGetUserDetailsRequest(username);
            Assert.IsNotNull(response);
            var user = driver.GetResponseContent<Users>(response);
            return user;

        }
    }
}
