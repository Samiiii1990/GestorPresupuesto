using Model;
using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Modelo> Gastos => _database.GetCollection<Modelo>("Gastos");
    public IMongoCollection<Modelo> Ingresos => _database.GetCollection<Modelo>("Ingresos");

}