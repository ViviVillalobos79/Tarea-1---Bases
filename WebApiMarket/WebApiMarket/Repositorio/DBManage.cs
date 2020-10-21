using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace WebApiMarket.Repositorios
{
    class MongoCRUD
    {
        private IMongoDatabase db;

        ///<summary>
        ///Constructor de la clase
        ///</summary>
        ///<param name="database">
        ///Base de datos a usar
        ///</param>
        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        ///<summary>
        ///Inserta un valor en la tabla dada
        ///</summary>
        ///<param name="table">
        ///Tabla donde se guarda el valor
        ///</param>
        ///<param name="record">
        ///Valor a guardar
        ///</param>
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        ///<summary>
        ///Obtiene todos los valores en una tabla dada
        ///</summary>
        ///<return>
        ///Devuelve una lista con los valores de la tabla
        ///</return>
        ///<param name="table">
        ///Tabla de donde se desean los valores
        ///</param>
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        ///<summary>
        ///Obtiene el valor de la tabla con un ID específico
        ///</summary>
        ///<return>
        ///Devuelve el valor con dicho ID
        ///</return>
        ///<param name="table">
        ///Tabla de donde se desean los valores
        ///</param>
        ///<param name="id">
        ///Id único con el cual se busca
        ///</param>
        public T LoadRecordbyId<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }

        ///<summary>
        ///Eliminar un dato en específico
        ///</summary>
        ///<param name="table">
        ///Tabla de donde se desea borrar el valor
        ///</param>
        ///<param name="id">
        ///Id único con el cual se busca borrar
        ///</param>
        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }



    }
}

