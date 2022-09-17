using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace ApiVendas.Models;

/// Enum Região para obter os dados
public enum Regions
{
  
    Norte,
    Nordeste,
    Sudeste,
    Centro_Oeste,
    Sul
}
    /// Atributos para a classe vendedor
public class VendedorModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = null!;


    [BsonElement("name")]
    public string Name { get; set; } = null!;


    [BsonElement("email")]
    public string Email { get; set; } = null!;


    [BsonElement("region")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Regions Region { get; set; }



}

