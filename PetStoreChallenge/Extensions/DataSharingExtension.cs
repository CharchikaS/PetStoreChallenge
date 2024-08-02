using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using PetStoreChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreChallenge.Extensions
{
    public static class DataSharingExtension
    {
        private const string UserId = "UserId";
        private const string UserName = "UserName";
        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string EmailId = "EmailId";
        private const string Password = "Password";
        private const string Phone = "Phone";
        private const string CreateUser = "CreateUser";
        private const string ResponseStatusCode = "ResponseStatusCode";
        private const string ResponseContent = "ResponseContent";
        private const string CreatePet = "CreatePet";
        private const string PetId = "PetId";
        private const string PetStatus = "PetStatus";
        private const string PetResponseContent = "PetResponseContent";
        private const string BulkUsersList = "BulkUsersList";


        public static void SetUserId(this ScenarioContext scenarioContext, Int64 value) => scenarioContext[UserId] = value;
        public static Int64 GetUserId(this ScenarioContext scenarioContext) => scenarioContext.Get<Int64>(UserId);
        public static void SetUserName(this ScenarioContext scenarioContext, string value) => scenarioContext[UserName] = value;
        public static string GetUserName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(UserName);
        public static void SetFirstName(this ScenarioContext scenarioContext, string value) => scenarioContext[FirstName] = value;
        public static string GetFirstName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(FirstName);
        public static void SetLastName(this ScenarioContext scenarioContext, string value) => scenarioContext[LastName] = value;
        public static string GetLastName(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(LastName);
        public static void SetEmailId(this ScenarioContext scenarioContext, string value) => scenarioContext[EmailId] = value;
        public static string GetEmailId(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(EmailId);
        public static void SetPassword(this ScenarioContext scenarioContext, string value) => scenarioContext[Password] = value;
        public static string GetPassword(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(Password);
        public static void SetPhone(this ScenarioContext scenarioContext, string value) => scenarioContext[Phone] = value;
        public static string GetPhone(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(Phone);
        public static void SetUser(this ScenarioContext scenarioContext, Users value) => scenarioContext[CreateUser] = value;
        public static Users GetUser(this ScenarioContext scenarioContext)
        {
            if (scenarioContext.TryGetValue<Users>(CreateUser, out Users value))
                return value;
            return new Users();
        }
        public static void SetResponseStatusCode(this ScenarioContext scenarioContext, System.Net.HttpStatusCode value) => scenarioContext[ResponseStatusCode] = value;
        public static System.Net.HttpStatusCode GetResponseStatusCode(this ScenarioContext scenarioContext) => scenarioContext.Get<System.Net.HttpStatusCode>(ResponseStatusCode);
        public static void SetResponseContent(this ScenarioContext scenarioContext, Users value) => scenarioContext[ResponseContent] = value;
        public static Users GetResponseContent(this ScenarioContext scenarioContext) => scenarioContext.Get<Users>(ResponseContent);
        public static void SetPet(this ScenarioContext scenarioContext, Pets value) => scenarioContext[CreatePet] = value;
        public static Pets GetPet(this ScenarioContext scenarioContext)
        {
            if (scenarioContext.TryGetValue<Pets>(CreatePet, out Pets value))
                return value;
            return new Pets();
        }
        public static void SetPetId(this ScenarioContext scenarioContext, Int64 value) => scenarioContext[PetId] = value;
        public static Int64 GetPetId(this ScenarioContext scenarioContext) => scenarioContext.Get<Int64>(PetId);
        public static void SetPetStatus(this ScenarioContext scenarioContext, string value) => scenarioContext[PetStatus] = value;
        public static string GetPetStatus(this ScenarioContext scenarioContext) => scenarioContext.Get<string>(PetStatus);
        public static void SetPetResponseContent(this ScenarioContext scenarioContext, List<Pets> value) => scenarioContext[PetResponseContent] = value;
        public static List<Pets> GetPetResponseContent(this ScenarioContext scenarioContext) => scenarioContext.Get<List<Pets>>(PetResponseContent);
        public static void SetBulkUsersList(this ScenarioContext scenarioContext, List<Users> value) => scenarioContext[BulkUsersList] = value;
        public static List<Users> GetBulkUsersList(this ScenarioContext scenarioContext) => scenarioContext.Get<List<Users>>(BulkUsersList);
    }
}
