using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApiMarket.DB
{
    class Producto
    {
        [BsonId]
        public Guid Id { get; set; }
        public int Num_Producto { get; set; }
        public string Nombre { get; set; }
        public int id_categoria { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Modo_venta { get; set; }
        public bool Disponibilidad { get; set; }
        public int CedulaProductor { get; set; }
    }
}
