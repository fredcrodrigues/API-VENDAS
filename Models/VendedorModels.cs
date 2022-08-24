using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace ApiVendas.Models;

public enum Regiao
{
    Norte,
    Nordeste,
    Sudeste,
    Centro_Oeste,
    Sul
}

public class VendedorModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("nome")]
    public string Nome { get; set; }
 
    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("regiao")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Regiao Regiao { get; set; }
   
}

