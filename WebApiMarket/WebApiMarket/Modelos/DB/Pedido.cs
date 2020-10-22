using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WebApiMarket.DB
{
    class Pedido
    {
        [BsonId]
        public Guid Id { get; set; }
        public string num_pedido { get; set; }
        public string monto { get; set; }
        public List<string> productos { get; set; }
        public List<string> cantproductos { get; set; }
        public string numcomprobante { get; set; }
        public string cedulacliente { get; set; }
        public bool entregado { get; set; }
    }
}
