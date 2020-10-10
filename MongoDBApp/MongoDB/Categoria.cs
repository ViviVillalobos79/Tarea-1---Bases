using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class Categoria
{
    [BsonId]
    public Guid Id { get; set; }
    public string IdCategoria { get; set; }
    public string Nombre { get; set; }

}
