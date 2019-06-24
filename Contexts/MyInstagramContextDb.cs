using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace MyInstagramApi.Contexts
{
    public class MyInstagramContextDb
    {
        private static readonly string DatabaseName = "myinstagram";

        public IMongoDatabase MongoDatabase { get; }

        public MyInstagramContextDb()
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var client = new MongoClient(configuration.GetConnectionString("ConnectionStringMongoDb"));

            MongoDatabase = client.GetDatabase(DatabaseName);
        }

    }
}
