using Newtonsoft.Json;


namespace PetStoreChallenge.Models
{
    public class Pets
    {
        [JsonProperty("id")]
        public Int64 Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public List<Category> Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
