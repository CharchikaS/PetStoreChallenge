using Newtonsoft.Json;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using RestSharp;


namespace PetStoreChallenge.Extensions
{
    public static class PetExtension
    {
        public static Pets InitializeNewPet(this Pets pet)
        {
            Console.WriteLine("inside InitializeNewPet");
            Random random = new Random();
            pet.Id = 5;
            Category category = new Category();
            category.Id = random.NextInt64();
            category.Name = "Birds";
            pet.Name = "Maina";
            pet.Status = "available";
            return pet;
        }
        public static IRestResponse SendPetCreationRequest(this Pets pet)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("pet");
            var jsonRequestBody = JsonConvert.SerializeObject(pet, Formatting.Indented);
            Console.WriteLine(jsonRequestBody);
            var request = driver.CreatePOSTRequest(jsonRequestBody);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Pet Creation response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendUploadImageRequest(this Pets pet, Int64 petId)
        {
            var file = File.ReadAllBytes(@".\Inputs\jerry.PNG");

            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("pet/{petId}/uploadImage");
            var request = driver.CreatePOSTRequest(file);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddUrlSegment("petId", petId);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Image upload response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendGetPetsRequest(this Pets pet, string status)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("pet/findByStatus");
            var request = driver.CreateGETRequest();
            request.AddQueryParameter("status", status);    
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Get Pets response code: {response.StatusCode}");
            return response;
        }
    }
}
