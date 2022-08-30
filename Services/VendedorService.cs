using Microsoft.Extensions.Options;
using ApiVendas.Models;
using MongoDB.Driver;


namespace ApiVendas.Services;

public class VendedorService
{
    public readonly IMongoCollection<VendedorModels> _databaseSettingsModels;
    

     public VendedorService(IOptions<DatabaseSettingsModels> databaseSettingsModels)
     {
        var mongoClient = new MongoClient(
           databaseSettingsModels.Value.ConnectionString
        );
        var mogoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.DatabaseName);
        _databaseSettingsModels = mogoDatabase.GetCollection<VendedorModels>(databaseSettingsModels.Value.VendedorCollection);
     }

    public async Task<List<VendedorModels>> GetAsync() => await _databaseSettingsModels.Find(_ => true).ToListAsync();
    public async Task<VendedorModels> GetId(string id) =>  await _databaseSettingsModels.Find(x => x.Id == id).FirstOrDefaultAsync();
  

    public async Task Create(VendedorModels date)
    {
       

        await _databaseSettingsModels.InsertOneAsync(date);
    }

}
