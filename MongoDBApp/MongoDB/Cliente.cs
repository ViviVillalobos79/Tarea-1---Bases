using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class Cliente
{
    public string Cedula { get; set; }
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Usuario { get; set; }
    public Nombre_Persona Nombre { get; set; }
    public Direccion direccion { get; set; }
    public DOB dob { get; set; }
    public string telefono { get; set; }
    public string SINPE { get; set; }
    public string pass { get; set; }

}
