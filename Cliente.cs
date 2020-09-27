using System;

public class Cliente
{
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Cedula { get; set; }
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Usuario { get; set; }
    public Nombre_Persona Nombre { get; set; }
    public Direccion direccion { get; set; }
    public DOB dob { get; set; }
    public string telefono { get; set; }
    public string SINPE { get; set; }
    public string pass { get; set; }
}
