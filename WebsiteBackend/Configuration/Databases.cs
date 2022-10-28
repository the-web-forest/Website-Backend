using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WebsiteBackend.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace WebsiteBackend.Configuration;
public static class Databases
{
    public static void Configure(IFunctionsHostBuilder builder, IConfigurationRoot config)
    {
        string connectionString = config["Values:Database:ConnectionString"];
        string database = config["Values:Database:Name"];

        var Database = new MongoClient(connectionString).GetDatabase(database);
        ConfigureUserCollection(Database);

        builder.Services.AddSingleton(x => Database);
    }

    private static void ConfigureUserCollection(IMongoDatabase Database)
    {
        var UserCollection = Database.GetCollection<Certificate>(typeof(Certificate).Name);
        var indexOptions = new CreateIndexOptions();
        var indexKeys = Builders<Certificate>.IndexKeys.Ascending(x => x.CreatedAt);
        var indexModel = new CreateIndexModel<Certificate>(indexKeys, indexOptions);
        UserCollection.Indexes.CreateOne(indexModel);
    }
}