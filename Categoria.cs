using System;

public class Categoria
{
    [BsonId] //unic identifier sino se pone uno mongo lo pone automatico
    public Guid Id { get; set; }
    public string Nombre { get; set; }

}
