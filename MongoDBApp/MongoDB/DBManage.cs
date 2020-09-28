using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class MongoCRUD
{
    private IMongoDatabase db;

    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        db = client.GetDatabase(database);
    }

    public void InsertRecord<T>(string table, T record)
    {
        var collection = db.GetCollection<T>(table); //Es como la tabla, que es el conjunto de los records
        collection.InsertOne(record); //Pone el 
    }

    public List<T> LoadRecords<T>(string table)
    {
        var collection = db.GetCollection<T>(table);
        return collection.Find(new BsonDocument()).ToList();
    }

    public T LoadRecordbyId<T>(string table, Guid id)
    {
        var collection = db.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("Id", id);
        return collection.Find(filter).First();
    }

    [Obsolete]
    public void UpsertRecord<T>(string table, Guid id, T record) //create or insert depends, si ya existe lo actualiza sino lo crea
    {
        var collection = db.GetCollection<T>(table);
        var result = collection.ReplaceOne(
            new BsonDocument("_id", id),
            record,
            new UpdateOptions { IsUpsert = true });
    }

    public void DeleteRecord<T>(string table, Guid id, T record)
    {
        var collection = db.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("Id", id);
        collection.DeleteOne(filter);
    }

}

