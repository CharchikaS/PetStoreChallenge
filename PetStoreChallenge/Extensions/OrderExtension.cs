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
    public static class OrderExtension
    {
        public static Orders InitializeNewUser(this Orders order)
        {
            Random random = new Random();
            order.Id = 5;
            order.PetId = 5;
            order.Quantity = 5;
            order.ShipDate = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00");
            order.Status = "placed";
            order.Complete = true;
            return order;
        }
        public static IRestResponse SendorderCreationRequest(this Orders newOrder)
        {
            APIRequestDriver driver = new APIRequestDriver();
            var url = driver.SetUrl("store/order");
            var jsonRequestBody = JsonConvert.SerializeObject(newOrder, Formatting.Indented);
            Console.WriteLine(jsonRequestBody);
            var request = driver.CreatePOSTRequest(jsonRequestBody);
            var response = driver.GetResponse(url, request);
            Console.WriteLine($"Order Creation response code: {response.StatusCode}");
            return response;
        }
    }
}
