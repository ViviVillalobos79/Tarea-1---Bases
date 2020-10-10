using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
            //  localhost:1050/DelCliente/117480511/


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
                var recs = db.LoadRecords<Productor>("Productores");
                var productores = new List<Productor> {};
                foreach (var rec in recs)
                {
                    if (rec.direccion.Distrito == filtro)
                    {
                        productores.Add(rec);

                    }
                }
                var json = productores.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }
            if (instruccion == "PedidosProductor")
            {
                var recs = db.LoadRecords<Productor>("Productores");
                var num_pedidos = new List<string> { };
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro)
                    {
                        num_pedidos = rec.pedidos;
                    }
                }

                var recsa = db.LoadRecords<Pedido>("Pedidos");
                var pedidos = new List<Pedido> { };
                foreach (var rec in recsa)
                {
                    if (num_pedidos.Contains(rec.num_pedido))
                    {
                        pedidos.Add(rec);
                    }
                }

                var json = pedidos.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);
            }
            if (instruccion == "PedidosCliente")
            {
                var recs = db.LoadRecords<Cliente>("Clientes");
                var num_pedidos = new List<string> { };
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro)
                    {
                        num_pedidos = rec.pedidos;
                    }
                }

                var recsa = db.LoadRecords<Pedido>("Pedidos");
                var pedidos = new List<Pedido> { };
                foreach (var rec in recsa)
                {
                    if (num_pedidos.Contains(rec.num_pedido))
                    {
                        pedidos.Add(rec);
                    }
                }

                var json = pedidos.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);
            }
            

            if (instruccion == "DelCliente")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();

            }
            if (instruccion == "DelProductor")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }
            if (instruccion == "DelPedido")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }
            if (instruccion == "DelCategoria")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Categoria>("Categorias");
                var filter = Builders<Categoria>.Filter.Eq(x => x.IdCategoria, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            MongoCRUD db = new MongoCRUD("FoodGos");

        // localhost: 1050 / DelCliente y el body

            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();
            Console.WriteLine(data);

            if (p.http_url == "/AddCliente")
            {
                var valor = JsonSerializer.Deserialize<Cliente>(data);
                db.InsertRecord<Cliente>("Clientes", valor);
            }
            if (p.http_url == "/AddProductor")
            {
                var valor = JsonSerializer.Deserialize<Productor>(data);
                db.InsertRecord<Productor>("Productores", valor);
            }
            if (p.http_url == "/AddPedido")
            {
                var valor = JsonSerializer.Deserialize<Pedido>(data);
                db.InsertRecord<Pedido>("Pedidos", valor);
            }
            if (p.http_url == "/AddCategoria")
            {
                var valor = JsonSerializer.Deserialize<Categoria>(data);
                db.InsertRecord<Categoria>("Categorias", valor);
            }

            if (p.http_url == "/UpdCliente")
            {
                var valor = JsonSerializer.Deserialize<Cliente>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);             
                db.InsertRecord<Cliente>("Clientes", valor);
            }
            if (p.http_url == "/UpdProductor")
            {
                var valor = JsonSerializer.Deserialize<Productor>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);
                db.InsertRecord<Productor>("Productores", valor);
            }
            if (p.http_url == "/UpdPedido")
            {
                var valor = JsonSerializer.Deserialize<Pedido>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, valor.num_pedido);
                collection.DeleteOne(filter);
                db.InsertRecord<Pedido>("Pedidos", valor);
            }
            if (p.http_url == "/UpdCategoria")
            {
                var valor = JsonSerializer.Deserialize<Categoria>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("FoodGos");
                var collection = dba.GetCollection<Categoria>("Categorias");
                var filter = Builders<Categoria>.Filter.Eq(x => x.IdCategoria, valor.IdCategoria);
                collection.DeleteOne(filter);
                db.InsertRecord<Categoria>("Categorias", valor);
            }

            p.writeSuccess();
            

        }


    }
}
