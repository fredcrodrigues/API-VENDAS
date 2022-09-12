using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ApiVendas.Class;
namespace ApiVendas.Models
{
    /// Atributos para a classe oportunidades
public class OportunidadeModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id = null;

    [BsonElement("cnpj")]
    public CNPJ Cnpj { get; set; } = null!;

    [BsonElement("name")]
    public string Nome { get; set; } = null!;


    [BsonElement("value")]
    public decimal Valor { get; set; }


    [BsonElement("seller")]
    public VendedorModels Vendedor { get; set; } = null!;

}
}