using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreChallenge.Helpers;
using PetStoreChallenge.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreChallenge.Extensions
{
    public static class UserExtension
    {
        public static Users AddFirstName(this Users user, string firstname)
        {
            user.FirstName = firstname;
            return user;
        }
        public static Users AddLastName(this Users user, string lastname)
        {
            user.LastName = lastname;
            return user;
        }
        public static Users AddUserName(this Users user, string username)
        {
            user.Username = username;
            return user;
        }
        public static Users AddEmail(this Users user, string email)
        {
            user.Email = email;
            return user;
        }
        public static Users AddPassword(this Users user, string pwd)
        {
            user.Password = pwd;
            return user;
        }
        public static Users AddPhone(this Users user, string phone)
        {
            user.Phone = phone;
            return user;
        }
        public static Users InitializeNewUser(this Users user)
        {
            Random random = new Random();
            user.Id = random.NextInt64();
            user.FirstName = "firstName";
            user.LastName = "lastName";
            user.Username = TestContext.CurrentContext.Random.GetString(); 
            user.Email = "email@gmail.com";
            user.Password = TestContext.CurrentContext.Random.GetString();
            user.Phone = TestContext.CurrentContext.Random.GetString();
            user.UserStatus = 1;
            return user;
        }
        public static IRestResponse SendUserCreationRequest(this Users newUser)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("user");
            var jsonRequestBody = JsonConvert.SerializeObject(newUser, Formatting.Indented);
            Console.WriteLine(jsonRequestBody);
            var request = driver.CreatePOSTRequest(jsonRequestBody);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"User Creation response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendGetUserDetailsRequest(this Users user,string username)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("user/{username}");
            var request = driver.CreateGETRequest();
            request.AddUrlSegment("username", username);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Get User response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendUpdateUserDetailsRequest(this Users user, string username)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("user/{username}");
            var jsonRequestBody = JsonConvert.SerializeObject(user);
            var request = driver.CreatePUTRequest(jsonRequestBody);
            request.AddUrlSegment("username", username);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Update User response code: {response.StatusCode}");
            return response;
        }
        public static IRestResponse SendDeleteUserDetailsRequest(this Users user, string username)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("user/{username}");
            var jsonRequestBody = JsonConvert.SerializeObject(user);
            var request = driver.CreateDELETERequest(jsonRequestBody);
            request.AddUrlSegment("username", username);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Delete User response code: {response.StatusCode}");
            return response;
        }
        public static List<Users> CreateBulkNewUsersList(this Users user)
        {
            try
            {
                List<Users> NewUsersList = File.ReadAllLines(@"C:\Users\w111962\source\repos\PetStoreChallenge\PetStoreChallenge\Inputs\NewUsers.csv")
                                           .Skip(1)
                                           .Select(v => CsvDriver.FromCsv(v))
                                           .ToList();
                return NewUsersList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }
        public static IRestResponse SendBulkUsersCreationRequest(this List<Users> newUsers, string requestType)
        {
            APIRequestDriver driver = new APIRequestDriver();
            string jsonRequestBody;
            string requestUrl;
            Console.WriteLine(requestType);

            switch (requestType)
            {
                case ("Array"):
                    jsonRequestBody = JsonConvert.SerializeObject(newUsers.ToArray());
                    requestUrl = "user/createWithArray";
                    break;
                default:
                    jsonRequestBody = JsonConvert.SerializeObject(newUsers);
                    requestUrl = "user/createWithList";
                    break;
            }
            var url = driver.SetUrl(requestUrl);
            Console.WriteLine(requestUrl);
            var request = driver.CreatePOSTRequest(jsonRequestBody);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Users Creation response code: {response.StatusCode}");
            return response;
        }
    }
}
