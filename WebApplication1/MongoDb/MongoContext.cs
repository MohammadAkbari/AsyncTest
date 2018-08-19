using MongoDB.Driver;

namespace WebApplication1.MongoDb
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            _database = client.GetDatabase("performance");
        }

        public IMongoCollection<Item> Items => _database.GetCollection<Item>(nameof(Items));
    }
}