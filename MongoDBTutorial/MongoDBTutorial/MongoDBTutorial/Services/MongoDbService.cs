using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBTutorial.DBSettings.Implementations;
using MongoDBTutorial.Models;

namespace MongoDBTutorial.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Developer> _developerCollection;

        public MongoDbService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _developerCollection = database.GetCollection<Developer>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Developer>> GetAsync()
        {
            return await _developerCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Developer developer)
        {
            await _developerCollection.InsertOneAsync(developer);
            return;
        }
        public async Task AddToFavLanguagesAsync(string id, string languageId)
        {
            FilterDefinition<Developer> filter = Builders<Developer>.Filter.Eq("Id", id);

            UpdateDefinition<Developer> update = Builders<Developer>.Update.AddToSet<string>("languageIds", languageId);

            await _developerCollection.UpdateOneAsync(filter, update);
        }
        public async Task DeleteAsync(string id) 
        { 
            FilterDefinition<Developer> filter=Builders<Developer>.Filter.Eq("Id", id);

            await _developerCollection.DeleteOneAsync(filter);

            return;
        }
    }
}






