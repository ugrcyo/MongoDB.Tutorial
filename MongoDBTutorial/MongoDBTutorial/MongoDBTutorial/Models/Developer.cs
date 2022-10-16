using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoDBTutorial.Models
{
    public class Developer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Title { get; set; }

        //public List<string> items { get; set; } = null!;

        //public Developer(string name,string surname,string title, List<string> languageIds)
        //{
        //    this.Name = name;
        //    this.SurName = surname;
        //    this.Title = title;
        //    this.items = languageIds;
        //}
        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> languageIds { get; set; } = null!;
    }
}
