using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using WebApiMarket.Modelos;

namespace WebApiMarket.DB
{
    class Cliente
    {
        [BsonId]
        public Guid Id { get; set; }
        public int Cedula { get; set; }
        public string Usuario { get; set; }
        public List<string> Nombre { get; set; } //[Nombre, Apellido1, Apellido2]
        public List<string> direccion { get; set; } //[Provincia, Cantón, Distrito]
        public List<int> dob { get; set; } //[Dia, Mes, Año]
        public int telefono { get; set; }
        public int SINPE { get; set; }
        public string pass { get; set; }
        public bool aceptado { get; set; }
        public List<int> pedidos { get; set; }
    }
}
