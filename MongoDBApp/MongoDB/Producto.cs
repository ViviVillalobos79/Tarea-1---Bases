using MongoDB.Bson.Serialization.Attributes;
using System;

public class Producto
{
    [BsonId]
    public Guid Id { get; set; }
    public string Num_Producto { get; set; }
    public string Nombre { get; set; }
    public Categoria categoria { get; set; }
    public int Precio { get; set; }
    public int Cantidad { get; set; }
    public string Modo_venta { get; set; }
    public string Disponibilidad { get; set; }
    public string CedulaProductor { get; set; }
}
