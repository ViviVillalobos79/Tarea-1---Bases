using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer httpServer;
            if (args.GetLength(0) > 0)
            {
                httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
            }
            else
            {
                httpServer = new MyHttpServer(1050);
            }
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();



            //MongoCRUD db = new MongoCRUD("FoodGos"); //I doesnt exist then is create

            //var recs = db.LoadRecordby<Cliente>("Clientes", "Cedula", "117480511");

            //var recsa = db.LoadRecords<Cliente>("Clientes");

            //var json2 = recs.ToJson();

            //foreach (var rec in recsa)
            //{
            //    var json = rec.ToJson();

            //    Console.WriteLine(json);
            //}

            //Console.WriteLine(json2);

            //                                        /////////// EJEMPLO de como insertar 
            //db.InsertRecord("Clientes", new Cliente
            //{
            //    Cedula = "117480511",
            //    Nombre = new Nombre_Persona { Primer_Nombre = "Maesly", Apellido1 = "Villalobos", Apellido2 = "Valverde" },
            //    direccion = new Direccion { Provincia = "San Jose", Canton = "San Jose", Distrito = "Hatillo" },
            //    dob = new DOB { Dia = "10", Mes = "07", Year = "1999" },
            //    telefono = "61682819",
            //    pass = "hola123"
            //}); //Lo convierte en JSON y lo mete, pero se llama BSON
            Console.ReadLine();
        }
    }
}
