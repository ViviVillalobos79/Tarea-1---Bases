using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
            static void Main(string[] args)

            MongoCRUD db = new MongoCRUD("FoodGo"); //I doesnt exist then is create
            db.InsertRecord("Clientes",new Cliente );
        
        
            //Lo convierte en JSON y lo mete, pero se llama BSON
            //var recs = db.LoadRecords<PersonModel>("Clientes");
            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id}:{rec.FirstName} {rec.LastName}");
            //    Console.WriteLine();
            //}

            //db.LoadRecordbyId<PersonModel>("Clientes", new Guid("23449"));

            Console.ReadLine();
        }
}
