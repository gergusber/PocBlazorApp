using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace CRUDPOC.Domain.models
{
    [Serializable]
    public class Film
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyNameAttribute("Id")]
        public string Id { get; set; }

        [JsonPropertyNameAttribute("Title")]
        public string Title { get; set; }

        [JsonPropertyNameAttribute("Director")]
        public string Director { get; set; }

        [JsonPropertyNameAttribute("ReleaseDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }
    }
}