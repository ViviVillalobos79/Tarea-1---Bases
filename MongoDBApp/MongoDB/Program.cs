using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //    //Este trozo es del servidor
            //HttpServer httpServer;
            //if (args.GetLength(0) > 0)
            //{
            //    httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
            //}
            //else
            //{
            //    httpServer = new MyHttpServer(1050);
            //}
            //Thread thread = new Thread(new ThreadStart(httpServer.listen));
            //thread.Start();

            //Este trozo sirve para popular la base de datos si está vacía
        //Populate populate = new Populate();
        //populate.productores();
        //populate.clientes();
        //populate.cateogiasA();

            Console.ReadLine();
        }
    }
}
