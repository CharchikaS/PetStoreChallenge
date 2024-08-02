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
    public static class LoginExtension
    {
        public static IRestResponse SendLoginRequest(this Users user,string username, string password)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("user/login");
            var request = driver.CreateGETRequest();
            request.AddQueryParameter("username", username);
            request.AddQueryParameter("password", password);
            Console.WriteLine($"Login username: {username}");
            Console.WriteLine($"Login password: {password}");
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Login response code: {response.StatusCode}");
            return response;
        }
    }
}
