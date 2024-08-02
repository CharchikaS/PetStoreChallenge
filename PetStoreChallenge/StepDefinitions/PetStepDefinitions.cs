using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreChallenge.Extensions;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace PetStoreChallenge.StepDefinitions
{
    [Binding]
    public class PetStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public PetStepDefinitions(ScenarioContext scenarioContext) {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I create the details of a new Pet")]
        public void GivenICreateTheDetailsOfANewPet()
        {
            Pets newPet = new Pets();
            newPet.InitializeNewPet();
            _scenarioContext.SetPetId(newPet.Id);            
            _scenarioContext.SetPet(newPet);
        }

        [When(@"I send pet creation request")]
        public void WhenISendPetCreationRequest()
        {
            var response = _scenarioContext.GetPet().SendPetCreationRequest();
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
            Console.WriteLine(response.StatusCode.ToString());
        }

        [Then(@"a new pet entry should be created successfully")]
        public void ThenANewPetEntryShouldBeCreatedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [When(@"I send the request to upload image of this pet")]
        public void WhenISendTheRequestToUploadImageOfThisPet()
        {
            var response = _scenarioContext.GetPet().SendUploadImageRequest(_scenarioContext.GetPetId());
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);
            Console.WriteLine(response.StatusCode.ToString());
        }

        [Then(@"the image should be uploaded successfully")]
        public void ThenTheImageShouldBeUploadedSuccessfully()
        {
            var responseStatusCode = _scenarioContext.GetResponseStatusCode();
            responseStatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [When(@"I send the request to find pets by status")]
        public void WhenISendTheRequestToFindPetsByStatus()
        {
            Pets pet = _scenarioContext.GetPet();
            var response = pet.SendGetPetsRequest(pet.Status);
            Assert.IsNotNull(response);
            _scenarioContext.SetResponseStatusCode(response.StatusCode);

            APIRequestDriver driver = new APIRequestDriver();
            List<Pets> petList = driver.GetListOfResponseContent<Pets>(response);

            _scenarioContext.SetPetResponseContent(petList);
        }

        [Then(@"I should get all the pets who have this status")]
        public void ThenIShouldGetAllThePetsWhoHaveThisStatus()
        {
            var petList = _scenarioContext.GetPetResponseContent();
            petList.Should().NotBeNull();
            //petList.ForEach(pet => { });
            Console.WriteLine($"{petList.Count} pets");
        }
    }
}
