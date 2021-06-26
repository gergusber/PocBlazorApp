using System;
using System.Text.Json.Serialization;

namespace CRUDPOC.Shared.Dto
{
    [Serializable]
    public class DeveloperDto
    {
        [JsonPropertyNameAttribute("Id")]
        public int Id { get; set; }

        [JsonPropertyNameAttribute("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyNameAttribute("LastName")]
        public string LastName { get; set; }

        [JsonPropertyNameAttribute("Email")]
        public string Email { get; set; }

        [JsonPropertyNameAttribute("Experience")]
        public decimal Experience { get; set; }
    }
}