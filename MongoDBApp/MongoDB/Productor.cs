using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class Productor
{
    [BsonId]
    public Guid Id { get; set; }
    public string Cedula { get; set; }
    public Nombre_Persona Nombre { get; set; }
    public Direccion direccion { get; set; }
    public DOB dob { get; set; }
    public string telefono { get; set; }
    public string SINPE { get; set; }
    public List<Producto> productos { get; set; }
    public List<Producto> pedidos { get; set; }
}
