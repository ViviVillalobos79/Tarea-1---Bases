using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApiMarket.DB
{
    class Producto
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Num_Producto { get; set; }
        public string Nombre { get; set; }
        public string id_categoria { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
        public string Modo_venta { get; set; }
        public bool Disponibilidad { get; set; }
        public string CedulaProductor { get; set; }
    }
}
