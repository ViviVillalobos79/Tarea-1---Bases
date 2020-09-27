using System;

public class Productor
{
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Cedula { get; set; }
    public Nombre_Persona Nombre { get; set; }
    public Direccion direccion { get; set; }
    public DOB dob { get; set; }
    public string telefono { get; set; }
    public string SINPE { get; set; }
    public List<Producto> productos { get; set; }
}
