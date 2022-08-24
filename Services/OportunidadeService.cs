using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ApiVendas.Models;
using Newtonsoft.Json.Linq;

namespace ApiVendas.Services;

public class OportunidadeService
{

    public readonly IMongoCollection<OportunidadeModels> _databaseSettingsModels;
  
  
    public OportunidadeService(IOptions<DatabaseSettingsModels> databaseSettingsModels) {

        var mongoClient = new MongoClient(databaseSettingsModels.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.DatabaseName);
        _databaseSettingsModels = mongoDatabase.GetCollection<OportunidadeModels>(databaseSettingsModels.Value.OportunidadeCollection);
      
    }

    public async Task<List<OportunidadeModels>> GetAsync() => await _databaseSettingsModels.Find(_ => true).ToListAsync();


    public async Task Create(OportunidadeModels data)
    {
        await _databaseSettingsModels.InsertOneAsync(data);
        
    }
    

}




