using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ApiVendas.Models;
using Newtonsoft.Json.Linq;

namespace ApiVendas.Services;

public class OportunidadeService
{
    /// Injeção de dependecia com mongoDB e Chamado uma coleção especifica para  amanipulação dos dados
    public readonly IMongoCollection<OportunidadeModels> _configuracaoBancoModels;
    
  
    public OportunidadeService(IOptions<ConfiguracaoBancoModels> databaseSettingsModels) {

        var mongoClient = new MongoClient(databaseSettingsModels.Value.StringConexao);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.NomeBanco);
        _configuracaoBancoModels = mongoDatabase.GetCollection<OportunidadeModels>(databaseSettingsModels.Value.ColecaoOportunidade);
      
    }

    public async Task<List<OportunidadeModels>> AObterOportunidade() => await _configuracaoBancoModels.Find(_ => true).ToListAsync();

    public async Task<OportunidadeModels> AObterId(string id) => await _configuracaoBancoModels.Find(x => x.Vendedor.Id == id).FirstOrDefaultAsync();

    public async Task CriarOportunidade(OportunidadeModels dados)
    {
        await _configuracaoBancoModels.InsertOneAsync(dados);
        
    }
    

}




