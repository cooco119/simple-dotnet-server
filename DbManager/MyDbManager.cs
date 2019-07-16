using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace simple_dotnet_server.DbManager
{
    public class MyDbManager
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _collection;
        private static MyDbManager _instance;

        public static MyDbManager GetInstance()
        {
            _instance = _instance ?? new MyDbManager();
            return _instance;
        }

        public MyDbManager()
        {
            _client = new MongoClient(
                "mongodb://localhost:27017/test?w=majority"
            );
            _db = _client.GetDatabase("local");
            _collection = _db.GetCollection<BsonDocument>("test");
        }

        public bool WriteOnCollection(string data)
        {
            DateTime timestamp = DateTime.Now;
            var document = new BsonDocument
            {
                { "data", data },
                { "timestamp", timestamp }
            };

            _collection.InsertOne(document);

            return true;
        }
    }

}
