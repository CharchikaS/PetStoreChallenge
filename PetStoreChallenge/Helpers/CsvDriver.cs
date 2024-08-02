using PetStoreChallenge.Models;

namespace PetStoreChallenge.Helpers
{
    public class CsvDriver
    {
        Int64 Id;
        string Username;
        string FirstName;
        string LastName;
        string Email;
        string Password;
        string Phone;
        int UserStatus;
        public static Users FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Users user = new Users();
            user.Id = Convert.ToInt64(values[0]);
            user.Username = values[1];
            user.FirstName = values[2];
            user.LastName = values[3];
            user.Email = values[4];
            user.Password = values[5];
            user.Phone = values[6];
            user.UserStatus = Convert.ToInt32(values[7]);

            return user;
        }
    }
}
