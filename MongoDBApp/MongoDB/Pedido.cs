using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    class Pedido
    {
        [BsonId]
        public Guid Id { get; set; }
        public string num_pedido { get; set; }
        public List<Producto> productos { get; set; }
        public string num_comprobante { get; set; }
        public string Cedula_cliente { get; set; }
        public string entrgeado { get; set; }


    }
}
