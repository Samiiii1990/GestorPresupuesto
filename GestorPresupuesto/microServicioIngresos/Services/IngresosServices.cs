using Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace microServicioIngresos.Services;

public class IngresosServices
{
    private readonly IMongoCollection<Modelo> _ingresosCollection;

    public IngresosServices(
        IOptions<MongoDBSettings> mongodbDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            mongodbDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongodbDatabaseSettings.Value.DatabaseName);

        _ingresosCollection = mongoDatabase.GetCollection<Modelo>(
            mongodbDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Modelo>> GetAsync() =>
        await _ingresosCollection.Find(_ => true).ToListAsync();

    public async Task<Modelo?> GetAsync(string id) =>
        await _ingresosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Modelo newIngreso) =>
        await _ingresosCollection.InsertOneAsync(newIngreso);

    public async Task UpdateAsync(string id, Modelo updatedIngreso) =>
        await _ingresosCollection.ReplaceOneAsync(x => x.Id == id, updatedIngreso);

    public async Task RemoveAsync(string id) =>
        await _ingresosCollection.DeleteOneAsync(x => x.Id == id);
}