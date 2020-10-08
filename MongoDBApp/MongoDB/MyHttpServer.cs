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


            MongoCRUD db = new MongoCRUD("FoodGos"); //I doesnt exist then is create

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

            if (instruccion == "ObtenerCedula")
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

            //if (p.http_url.Equals("/Hola"))
            //{
            //    var recs = db.LoadRecordby<Cliente>("Clientes", "Pr", "117480511");

            //    var recsa = db.LoadRecords<Cliente>("Clientes");

               

            //    var json2 = recs.ToJson();

            //    p.writeSuccess();
            //    p.outputStream.WriteLine(json2);
            //}



            //Console.WriteLine("request: {0}", p.http_url);
            //p.writeSuccess();
            //p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            //p.outputStream.WriteLine("Current Time: " + DateTime.Now.ToString());
            //p.outputStream.WriteLine("url : {0}", p.http_url);

            //p.outputStream.WriteLine("<form method=post action=/form>");
            //p.outputStream.WriteLine("<input type=text name=foo value=foovalue>");
            //p.outputStream.WriteLine("<input type=submit name=bar value=barvalue>");
            //p.outputStream.WriteLine("</form>");
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
