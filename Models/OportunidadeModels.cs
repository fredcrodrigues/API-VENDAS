using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiVendas.Models;

public class CNPJ{

    public string Numero { get; set; }
    public  string Razao_social { get; set; }

    public string Estado { get; set; }

    public string Atividade { get; set; }

}
public class OportunidadeModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id;

    [BsonElement("cnpj")]
    public CNPJ Cnpj { get; set; }

    [BsonElement("nome")]
    public string Nome { get; set; }
   
    [BsonElement("valor")]
    public decimal Valor { get; set; }

    [BsonElement("vendedor")]
    public VendedorModels Vendedor { get; set; }
}
