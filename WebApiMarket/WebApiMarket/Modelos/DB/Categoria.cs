using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApiMarket.DB
{
    public class Categoria
    {
        [BsonId]
        public Guid Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

    }
}
