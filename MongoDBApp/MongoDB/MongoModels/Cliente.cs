using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class Cliente
{
    [BsonId]
    public Guid Id { get; set; }
    public int Cedula { get; set; }
    public string Usuario { get; set; }
    public Nombre_Persona Nombre { get; set; }
    public Direccion direccion { get; set; }
    public DOB dob { get; set; }
    public int telefono { get; set; }
    public int SINPE { get; set; }
    public string pass { get; set; }
    public List<int> pedidos { get; set; }

}
