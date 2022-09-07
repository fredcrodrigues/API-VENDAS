using Microsoft.Extensions.Options;
using ApiVendas.Models;
using MongoDB.Driver;


namespace ApiVendas.Services;

public class VendedorService
{
     /// Injeção de dependecia com mongoDB e Chamado uma coleção especifica para  a manipulação dos dados
     public readonly IMongoCollection<VendedorModels> _configuracaoBancoModels;
     public VendedorService(IOptions<ConfiguracaoBancoModels> databaseSettingsModels)
     {
        var mongoClient = new MongoClient(
           databaseSettingsModels.Value.StringConexao
        );
        var mogoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.NomeBanco);
        _configuracaoBancoModels = mogoDatabase.GetCollection<VendedorModels>(databaseSettingsModels.Value.ColecaoVendedor);
     }

    public async Task<List<VendedorModels>> AObterVendedor() => await _configuracaoBancoModels.Find(_ => true).ToListAsync();
    public async Task<VendedorModels> AObterId(string id) =>  await _configuracaoBancoModels.Find(x => x.Id == id).FirstOrDefaultAsync();
  

    public async Task ACriarVendedor(VendedorModels dados)
    {
       
        await _configuracaoBancoModels.InsertOneAsync(dados);
    }

}
