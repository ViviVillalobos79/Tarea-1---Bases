﻿using MongoDB.Bson;
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
        public int num_pedido { get; set; }
        public List<int> productos { get; set; }
        public int num_comprobante { get; set; }
        public int Cedula_cliente { get; set; }
        public bool entregado { get; set; }


    }
}
