﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace ApiVendas.Models;

/// Enum Região para obter os dados
public enum Regiao
{
    Vazio = 0,
    Norte = 1,
    Nordeste = 2,
    Sudeste = 3,
    Centro_Oeste = 4,
    Sul = 5
}
    /// Atributos para a classe vendedor
public class VendedorModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;


    [BsonElement("nome")]
    public string Nome { get; set; } = null!;


    [BsonElement("email")]
    public string Email { get; set; } = null!;


    [BsonElement("regiao")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Regiao Regiao { get; set; }



}

