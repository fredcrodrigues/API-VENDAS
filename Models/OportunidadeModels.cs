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
    public string? Id { get; set; } = null!;

    [BsonElement("cnpj")]
    public CNPJ Cnpj { get; set; } = null!;

    [BsonElement("name")]
    public string Name { get; set; } = null!;


    [BsonElement("value")]
    public decimal Value { get; set; }


    [BsonElement("seller")]
    public VendedorModels Seller { get; set; } = null!;

}
}