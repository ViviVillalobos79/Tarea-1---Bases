using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using WebApiMarket.Modelos;

namespace WebApiMarket.DB
{
    class Productor
    {
        [BsonId]
        public Guid Id { get; set; }
        public int Cedula { get; set; }
        public Nombre_Persona Nombre { get; set; }
        public Direccion direccion { get; set; }
        public DOB dob { get; set; }
        public int telefono { get; set; }
        public int SINPE { get; set; }
        public List<int> productos { get; set; }
        public List<int> pedidos { get; set; }
    }
}
