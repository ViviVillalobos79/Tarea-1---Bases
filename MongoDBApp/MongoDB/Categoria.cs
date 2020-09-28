using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class Categoria
{
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Id { get; set; }
    public string Nombre { get; set; }

}
