using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApiMarket.DB
{
    public class Categoria
    {
        [BsonId]
        public Guid Id { get; set; }
        public string idcategoria { get; set; }
        public string nombre { get; set; }

    }
}
