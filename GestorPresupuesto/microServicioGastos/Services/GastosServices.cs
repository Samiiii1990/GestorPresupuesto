using Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace microServicioGastos.Services;

public class GastosServices
{
    private readonly IMongoCollection<Modelo> _gastosCollection;

    public GastosServices(
        IOptions<MongoDBSettings> mongodbDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            mongodbDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongodbDatabaseSettings.Value.DatabaseName);

        _gastosCollection = mongoDatabase.GetCollection<Modelo>(
            mongodbDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Modelo>> GetAsync() =>
        await _gastosCollection.Find(_ => true).ToListAsync();

    public async Task<Modelo?> GetAsync(string id) =>
        await _gastosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Modelo newGasto) =>
        await _gastosCollection.InsertOneAsync(newGasto);

    public async Task UpdateAsync(string id, Modelo updatedGasto) =>
        await _gastosCollection.ReplaceOneAsync(x => x.Id == id, updatedGasto);

    public async Task RemoveAsync(string id) =>
        await _gastosCollection.DeleteOneAsync(x => x.Id == id);
}