using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiVendas.Models;

public class CNPJ{

    public string Numero { get; set; } = null!;
    public  string Razao_social { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Atividade { get; set; } = null!;

}
public class OportunidadeModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id = null;

    [BsonElement("cnpj")]
    public CNPJ Cnpj { get; set; } = null!;

    [BsonElement("nome")]
    public string Nome { get; set; } = null!;


    [BsonElement("valor")]
    public decimal Valor { get; set; }


    [BsonElement("vendedor")]
    public VendedorModels Vendedor { get; set; } = null!;

}
