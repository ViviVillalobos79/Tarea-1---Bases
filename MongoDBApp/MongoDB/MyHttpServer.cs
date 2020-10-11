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

        ///<summary>
        ///Maneja las solicitudes GET
        ///</summary>
        public override void handleGETRequest(HttpProcessor p)
        {
            
            MongoCRUD db = new MongoCRUD("Mercadito");  //Se obtiene la base que se va a estar usando

            var a = p.http_url; //URL que llega
            var instruccion = ""; //Lo que pide el cliente
            var filtro = ""; //Filtro de algo específico que solicita
            var slash = 0; //Contador
            var tam = a.Length;
            var i = 0;

            //Guarda la instrucción recibida y el filtro según lo que desea el cliente
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

            //Devuelve un cliente según el número de cédula
            //Ejemplo: localhost:1050/CedulaCliente/117480511/
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

            //Devuelve un productor según el número de cédula
            //Ejemplo: localhost:1050/CedulaProductor/117480511/
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

            //Devuelve un cliente según el nombre de usuario
            //Ejemplo: localhost:1050/UsuarioCliente/v_villalobos/
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

            //Devuelve una lista de todos los productores en el mismo distrito de un cliente según su número de cédula
            //Ejemplo: localhost:1050/Distritos/117480511/
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

            //Devuelve una lista con los pedidos de un productor según su número de cédula
            //Ejemplo: localhost:1050/PedidosProductor/117480511/
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

            //Devuelve una lista con los pedidos de un cliente según su número de cédula
            //Ejemplo: localhost:1050/PedidosCliente/117480511/
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

            //Elimina un cliente según su número de cédula
            //Ejemplo: localhost:1050/DelCliente/117480511/
            if (instruccion == "DelCliente")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();

            }

            //Elimina un productor según su número de cédula
            //Ejemplo: localhost:1050/DelProductor/117480511/
            if (instruccion == "DelProductor")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }

            //Elimina un pedido según su número de pedido
            //Ejemplo: localhost:1050/DelPedido/00215/
            if (instruccion == "DelPedido")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }

            //Elimina una categoría según su número de categoría
            //Ejemplo: localhost:1050/DelCategoria/00215/
            if (instruccion == "DelCategoria")
            {
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Categoria>("Categorias");
                var filter = Builders<Categoria>.Filter.Eq(x => x.IdCategoria, filtro);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }

            //Devuelve todos los datos de un tabla según la que se pida
            if (instruccion == "All")
            {
                //Ejemplo: localhost:1050/All/clientes/
                if (filtro == "clientes")
                {
                    var recs = db.LoadRecords<Cliente>("Clientes");
                }
                //Ejemplo: localhost:1050/All/productores/
                if (filtro == "productores")
                {
                    var recs = db.LoadRecords<Productor>("Productores");
                }
                //Ejemplo: localhost:1050/All/productos/
                if (filtro == "productos")
                {
                    var recs = db.LoadRecords<Producto>("Productos");
                }
                //Ejemplo: localhost:1050/All/pedidos/
                if (filtro == "pedidos")
                {
                    var recs = db.LoadRecords<Pedido>("Pedidos");
                }
                //Ejemplo: localhost:1050/All/categorias/
                if (filtro == "categorias")
                {
                    var recs = db.LoadRecords<Categoria>("Categorias");
                }

            }
        }

        ///<summary>
        ///Maneja las solicitudes POST
        ///</summary>
        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            MongoCRUD db = new MongoCRUD("Mercadito");

            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();
            Console.WriteLine(data);


            //Adiciona un cliente en la tabla si no hay ningún otro con el mismo número de cédula o nombre de usuario
            //Ejemplo: localhost:1050/AddCliente
            if (p.http_url == "/AddCliente")
            {
                var valor = JsonSerializer.Deserialize<Cliente>(data);
                db.InsertRecord<Cliente>("Clientes", valor);
            }

            //Adiciona un productor en la tabla si no hay ningún otro con el mismo número de cédula
            //Ejemplo: localhost:1050/AddProductor
            if (p.http_url == "/AddProductor")
            {
                var valor = JsonSerializer.Deserialize<Productor>(data);
                db.InsertRecord<Productor>("Productores", valor);
            }

            //Adiciona un pedido en la tabla si no hay ningún otro con el mismo número de pedido
            //Ejemplo: localhost:1050/AddPedido
            if (p.http_url == "/AddPedido")
            {
                var valor = JsonSerializer.Deserialize<Pedido>(data);
                db.InsertRecord<Pedido>("Pedidos", valor);
            }

            //Adiciona una categoría en la tabla si no hay ningún otra con el mismo número de categoría
            //Ejemplo: localhost:1050/AddCategoria
            if (p.http_url == "/AddCategoria")
            {
                var valor = JsonSerializer.Deserialize<Categoria>(data);
                db.InsertRecord<Categoria>("Categorias", valor);
            }

            //Actualiza un cliente y verifica con el número de cédula que se envía
            //Ejemplo: localhost:1050/UpdCliente
            if (p.http_url == "/UpdCliente")
            {
                var valor = JsonSerializer.Deserialize<Cliente>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);             
                db.InsertRecord<Cliente>("Clientes", valor);
            }

            //Actualiza un productor y verifica con el número de cédula que se envía
            //Ejemplo: localhost:1050/UpdProductor
            if (p.http_url == "/UpdProductor")
            {
                var valor = JsonSerializer.Deserialize<Productor>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);
                db.InsertRecord<Productor>("Productores", valor);
            }

            //Actualiza un pedido y verifica con el número de pedido
            //Ejemplo: localhost:1050/UpdPedido
            if (p.http_url == "/UpdPedido")
            {
                var valor = JsonSerializer.Deserialize<Pedido>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, valor.num_pedido);
                collection.DeleteOne(filter);
                db.InsertRecord<Pedido>("Pedidos", valor);
            }

            //Actualiza un categoría y verifica con el número de categoría
            //Ejemplo: localhost:1050/UpdCategoria
            if (p.http_url == "/UpdCategoria")
            {
                var valor = JsonSerializer.Deserialize<Categoria>(data);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Categoria>("Categorias");
                var filter = Builders<Categoria>.Filter.Eq(x => x.IdCategoria, valor.IdCategoria);
                collection.DeleteOne(filter);
                db.InsertRecord<Categoria>("Categorias", valor);
            }

            p.writeSuccess();
            
        }


    }
}
