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

    [BsonElement("nome")]
    public string Nome { get; set; } = null!;


    [BsonElement("valor")]
    public decimal Valor { get; set; }


    [BsonElement("vendedor")]
    public VendedorModels Vendedor { get; set; } = null!;

}
}