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

            //var json2 = recsa.ToJson();

            //foreach (var rec in recsa)
            //{
            //    var json = rec.ToJson();

            //    Console.WriteLine(json);
            //}

            //Console.WriteLine(json2);

            //                                        /////////// EJEMPLO de como insertar 
            //db.InsertRecord("Clientes", new Cliente
            //{
            //    Cedula = "305000397",
            //    Usuario = "Nickotronz7",
            //    Nombre = new Nombre_Persona { Primer_Nombre = "Nickolas", Apellido1 = "Rodriguez", Apellido2 = "Cordero" },
            //    direccion = new Direccion { Provincia = "Cartago", Canton = "El Guarco", Distrito = "Barrancas" },
            //    dob = new DOB { Dia = "05", Mes = "02", Year = "1997" },
            //    telefono = "61682819",
            //    SINPE = "61682819",
            //    pass = "hola123"
            //}); //Lo convierte en JSON y lo mete, pero se llama BSON




            Console.ReadLine();
        }
    }
}
