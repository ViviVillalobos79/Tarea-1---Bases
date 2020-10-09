using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MongoDB
{
    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(int port)
            : base(port)
        {
        }
        public override void handleGETRequest(HttpProcessor p)
        {


            MongoCRUD db = new MongoCRUD("FoodGos"); 

            var a = p.http_url;
            var instruccion = "";
            var filtro = "";
            var slash = 0;
            var tam = a.Length;
            var i = 0;

            while (i < tam && slash < 3)
            {
                if (a[i] == '/')
                {
                    slash += 1;
                }
                else if (slash == 1)
                {
                    instruccion = instruccion + a[i];
                }
                else if (slash == 2)
                {
                    filtro = filtro + a[i];
                }
                i += 1;
            }

            if (instruccion == "CedulaCliente")
            {
                var recs = db.LoadRecords<Cliente>("Clientes");
                var cliente = new Cliente();
                foreach (var rec in recs)
                {
                    if(rec.Cedula == filtro)
                    {
                        cliente = rec;
                        
                    }
                }
                var json = cliente.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }
            if (instruccion == "CedulaProductor")
            {
                var recs = db.LoadRecords<Productor>("Productores");
                var productor = new Productor();
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro)
                    {
                        productor = rec;
                    }
                }
                var json = productor.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);
            }
            if (instruccion == "UsuarioCliente")
            {
                var recs = db.LoadRecords<Cliente>("Clientes");
                var cliente = new Cliente();
                foreach (var rec in recs)
                {
                    if (rec.Usuario == filtro)
                    {
                        cliente = rec;

                    }
                }
                var json = cliente.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }
            if (instruccion == "Distritos")
            {
                var recs = db.LoadRecords<Cliente>("Productores");
                var productor = new Productor();
                var productores = new List<Productor> { productor };
                foreach (var rec in recs)
                {
                    if (rec.direccion.Distrito == filtro)
                    {
                        productores.Add(rec);

                    }
                }
                var json = cliente.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }




        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.writeSuccess();
            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);


        }

    }
}
