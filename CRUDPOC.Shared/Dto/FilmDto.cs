using System;
using System.Text.Json.Serialization;

namespace CRUDPOC.Shared.Dto
{
    [Serializable]
    public class FilmDto
    {
        [JsonPropertyNameAttribute("Id")]
        public string Id { get; set; }

        [JsonPropertyNameAttribute("Title")]
        public string Title { get; set; }

        [JsonPropertyNameAttribute("Director")]
        public string Director { get; set; }

        [JsonPropertyNameAttribute("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}