using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.NormalModels;
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

            //localhost:1050/api/instruccion/filtro/

            var a = p.http_url; //URL que llega
            var instruccion = ""; //Lo que pide el cliente
            var api = "";
            var filtro = ""; //Filtro de algo específico que solicita
            var slash = 0; //Contador
            var tam = a.Length;
            var i = 0;

            //Guarda la instrucción recibida y el filtro según lo que desea el cliente
            while (i < tam || slash < 4)
            {
                if (a[i] == '/')
                {
                    slash += 1;
                }
                else if (slash == 1)
                {
                    api = api + a[i];
                }
                else if (slash == 2)
                {
                    instruccion = instruccion + a[i];
                }
                else if (slash == 3)
                {
                    filtro = filtro + a[i];
                }
                i += 1;
            }

            //Devuelve un cliente según el número de cédula
            //Ejemplo: localhost:1050/CedulaCliente/117480511/
            if (instruccion == "CedulaCliente")
            {
                var filtro1 = int.Parse(filtro);
                var recs = db.LoadRecords<Cliente>("Clientes");
                var cliente = new Cliente();
                foreach (var rec in recs)
                {
                    if(rec.Cedula == filtro1)
                    {
                        cliente = rec;
                        
                    }
                }


                var cliente2 = new Cliente2
                {
                    Cedula = cliente.Cedula,
                    Usuario = cliente.Usuario,
                    Nombre = cliente.Nombre,
                    direccion = cliente.direccion,
                    dob = cliente.dob,
                    telefono = cliente.telefono,
                    SINPE = cliente.SINPE,
                    pass = cliente.pass,
                    pedidos = cliente.pedidos
                };

                var json = cliente2.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }

            //Devuelve un productor según el número de cédula
            //Ejemplo: localhost:1050/CedulaProductor/117480511/
            if (instruccion == "CedulaProductor")
            {
                var filtro1 = int.Parse(filtro);
                var recs = db.LoadRecords<Productor>("Productores");
                var productor = new Productor();
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro1)
                    {
                        productor = rec;
                    }
                }

                var productor2 = new Productor2
                {
                    Cedula = productor.Cedula,
                    Nombre = productor.Nombre,
                    direccion = productor.direccion,
                    dob = productor.dob,
                    telefono = productor.telefono,
                    SINPE = productor.SINPE,
                    productos = productor.productos,
                    pedidos = productor.pedidos
                };

                var json = productor2.ToJson();
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

                var cliente2 = new Cliente2
                {
                    Cedula = cliente.Cedula,
                    Usuario = cliente.Usuario,
                    Nombre = cliente.Nombre,
                    direccion = cliente.direccion,
                    dob = cliente.dob,
                    telefono = cliente.telefono,
                    SINPE = cliente.SINPE,
                    pass = cliente.pass,
                    pedidos = cliente.pedidos
                };

                var json = cliente2.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }

            //Devuelve una lista de todos los productores en el mismo distrito de un cliente según su número de cédula
            //Ejemplo: localhost:1050/Distritos/117480511/
            if (instruccion == "Distritos")
            {
                var filtro1 = int.Parse(filtro);
                var recs = db.LoadRecords<Cliente>("Clientes");
                var cliente = new Cliente();
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro1)
                    {
                        cliente = rec;

                    }
                }

                var recsa = db.LoadRecords<Productor>("Productores");
                var productores = new List<Productor> {};
                var productores2 = new List<Productor2> { };
                foreach (var rec in recsa)
                {
                    if (rec.direccion == cliente.direccion)
                    {
                        productores.Add(rec);

                    }
                }
                foreach (var productor in productores)
                {
                    var productor2 = new Productor2
                    {
                        Cedula = productor.Cedula,
                        Nombre = productor.Nombre,
                        direccion = productor.direccion,
                        dob = productor.dob,
                        telefono = productor.telefono,
                        SINPE = productor.SINPE,
                        productos = productor.productos,
                        pedidos = productor.pedidos
                    };
                    productores2.Add(productor2);
                }
                var json = productores2.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);

            }

            //Devuelve una lista con los pedidos de un productor según su número de cédula
            //Ejemplo: localhost:1050/PedidosProductor/117480511/
            if (instruccion == "PedidosProductor")
            {
                var filtro1 = int.Parse(filtro);
                var recs = db.LoadRecords<Productor>("Productores");
                var num_pedidos = new List<int> { };
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro1)
                    {
                        num_pedidos = rec.pedidos;
                    }
                }

                var recsa = db.LoadRecords<Pedido>("Pedidos");
                var pedidos = new List<Pedido> { };
                var pedidos2 = new List<Pedido2> { };
                foreach (var rec in recsa)
                {
                    if (num_pedidos.Contains(rec.num_pedido))
                    {
                        pedidos.Add(rec);
                    }
                }

                foreach (var pedido in pedidos)
                {
                    var pedido2 = new Pedido2
                    {
                        num_pedido = pedido.num_pedido,
                        productos = pedido.productos,
                        num_comprobante = pedido.num_comprobante,
                        Cedula_cliente = pedido.Cedula_cliente,
                        entregado = pedido.entregado
                    };

                    pedidos2.Add(pedido2);
                }

                var json = pedidos2.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);
            }

            //Devuelve una lista con los pedidos de un cliente según su número de cédula
            //Ejemplo: localhost:1050/PedidosCliente/117480511/
            if (instruccion == "PedidosCliente")
            {
                var filtro1 = int.Parse(filtro);
                var recs = db.LoadRecords<Cliente>("Clientes");
                var num_pedidos = new List<int> { };
                foreach (var rec in recs)
                {
                    if (rec.Cedula == filtro1)
                    {
                        num_pedidos = rec.pedidos;
                    }
                }

                var recsa = db.LoadRecords<Pedido>("Pedidos");
                var pedidos = new List<Pedido> { };
                var pedidos2 = new List<Pedido2> { };
                foreach (var rec in recsa)
                {
                    if (num_pedidos.Contains(rec.num_pedido))
                    {
                        pedidos.Add(rec);
                    }
                }

                foreach (var pedido in pedidos)
                {
                    var pedido2 = new Pedido2
                    {
                        num_pedido = pedido.num_pedido,
                        productos = pedido.productos,
                        num_comprobante = pedido.num_comprobante,
                        Cedula_cliente = pedido.Cedula_cliente,
                        entregado = pedido.entregado
                    };

                    pedidos2.Add(pedido2);
                }

                var json = pedidos2.ToJson();
                p.writeSuccess();
                p.outputStream.WriteLine(json);
            }

            //Elimina un cliente según su número de cédula
            //Ejemplo: localhost:1050/DelCliente/117480511/
            if (instruccion == "DelCliente")
            {
                var filtro1 = int.Parse(filtro);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, filtro1);
                collection.DeleteOne(filter);
                p.writeSuccess();

            }

            //Elimina un productor según su número de cédula
            //Ejemplo: localhost:1050/DelProductor/117480511/
            if (instruccion == "DelProductor")
            {
                var filtro1 = int.Parse(filtro);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, filtro1);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }

            //Elimina un pedido según su número de pedido
            //Ejemplo: localhost:1050/DelPedido/00215/
            if (instruccion == "DelPedido")
            {
                var filtro1 = int.Parse(filtro);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, filtro1);
                collection.DeleteOne(filter);
                p.writeSuccess();
            }

            //Elimina una categoría según su número de categoría
            //Ejemplo: localhost:1050/DelCategoria/00215/
            if (instruccion == "DelCategoria")
            {
                var filtro1 = int.Parse(filtro);
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Categoria>("Categorias");
                var filter = Builders<Categoria>.Filter.Eq(x => x.IdCategoria, filtro1);
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
                    var clientes2 = new List<Cliente2>{ };

                    foreach (var cliente in recs)
                    {
                        var cliente2 = new Cliente2
                        {
                            Cedula = cliente.Cedula,
                            Usuario = cliente.Usuario,
                            Nombre = cliente.Nombre,
                            direccion = cliente.direccion,
                            dob = cliente.dob,
                            telefono = cliente.telefono,
                            SINPE = cliente.SINPE,
                            pass = cliente.pass,
                            pedidos = cliente.pedidos
                        };

                        clientes2.Add(cliente2);

                    }
                    var json = clientes2.ToJson();
                    p.writeSuccess();
                    p.outputStream.WriteLine(json);

                }
                //Ejemplo: localhost:1050/All/productores/
                if (filtro == "productores")
                {
                    var recs = db.LoadRecords<Productor>("Productores");
                    var productores2 = new List<Productor2> { };

                    foreach (var productor in recs)
                    {
                        var productor2 = new Productor2
                        {
                            Cedula = productor.Cedula,
                            Nombre = productor.Nombre,
                            direccion = productor.direccion,
                            dob = productor.dob,
                            telefono = productor.telefono,
                            SINPE = productor.SINPE,
                            productos = productor.productos,
                            pedidos = productor.pedidos
                        };

                        productores2.Add(productor2);

                    }
                    var json = productores2.ToJson();
                    p.writeSuccess();
                    p.outputStream.WriteLine(json);
                }
                //Ejemplo: localhost:1050/All/productos/
                if (filtro == "productos")
                {
                    var recs = db.LoadRecords<Producto>("Productos");
                    var productos2 = new List<Producto2> { };

                    foreach (var producto in recs)
                    {
                        var producto2 = new Producto2
                        {
                            Num_Producto = producto.Num_Producto,
                            Nombre = producto.Nombre,
                            id_categoria = producto.id_categoria,
                            Precio = producto.Precio,
                            Cantidad = producto.Cantidad,
                            Modo_venta = producto.Modo_venta,
                            Disponibilidad = producto.Disponibilidad,
                            CedulaProductor = producto.CedulaProductor
                        };

                        productos2.Add(producto2);

                    }
                    var json = productos2.ToJson();
                    p.writeSuccess();
                    p.outputStream.WriteLine(json);
                }
                //Ejemplo: localhost:1050/All/pedidos/
                if (filtro == "pedidos")
                {
                    var recs = db.LoadRecords<Pedido>("Pedidos");
                    var pedidos2 = new List<Pedido2> { };

                    foreach (var pedido in recs)
                    {
                        var pedido2 = new Pedido2
                        {
                            num_pedido = pedido.num_pedido,
                            productos = pedido.productos,
                            num_comprobante = pedido.num_comprobante,
                            Cedula_cliente = pedido.Cedula_cliente,
                            entregado = pedido.entregado
                        };

                        pedidos2.Add(pedido2);

                    }
                    var json = pedidos2.ToJson();
                    p.writeSuccess();
                    p.outputStream.WriteLine(json);
                }
                //Ejemplo: localhost:1050/All/categorias/
                if (filtro == "categorias")
                {
                    var recs = db.LoadRecords<Categoria>("Categorias");
                    var categorias2 = new List<Categoria2> { };

                    foreach (var categoria in recs)
                    {
                        var categoria2 = new Categoria2
                        {
                            IdCategoria = categoria.IdCategoria,
                            Nombre = categoria.Nombre
                        };

                        categorias2.Add(categoria2);

                    }
                    var json = categorias2.ToJson();
                    p.writeSuccess();
                    p.outputStream.WriteLine(json);
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
            if (p.http_url == "/api/AddCliente")
            {
                Console.WriteLine("hola");
                //var valor2 = JsonSerializer.Deserialize<Cliente2>(data);
                //var valor = new Cliente
                //{
                //    Cedula = valor2.Cedula,
                //    Usuario = valor2.Usuario,
                //    Nombre = valor2.Nombre,
                //    direccion = valor2.direccion,
                //    dob = valor2.dob,
                //    telefono = valor2.telefono,
                //    SINPE = valor2.SINPE,
                //    pass = valor2.pass,
                //    pedidos = valor2.pedidos
                //};            

                //db.InsertRecord<Cliente>("Clientes", valor);
            }

            //Adiciona un productor en la tabla si no hay ningún otro con el mismo número de cédula
            //Ejemplo: localhost:1050/AddProductor
            if (p.http_url == "/api/AddProductor")
            {
                var valor2 = JsonSerializer.Deserialize<Productor2>(data);
                var valor = new Productor
                {
                    Cedula = valor2.Cedula,
                    Nombre = valor2.Nombre,
                    direccion = valor2.direccion,
                    dob = valor2.dob,
                    telefono = valor2.telefono,
                    SINPE = valor2.SINPE,
                    productos = valor2.productos,
                    pedidos = valor2.pedidos
                };

                db.InsertRecord<Productor>("Productores", valor);
            }

            //Adiciona un pedido en la tabla si no hay ningún otro con el mismo número de pedido
            //Ejemplo: localhost:1050/AddPedido
            if (p.http_url == "/api/AddPedido")
            {
                var valor2 = JsonSerializer.Deserialize<Pedido2>(data);
                var valor = new Pedido
                {
                    num_pedido = valor2.num_pedido,
                    productos = valor2.productos,
                    num_comprobante = valor2.num_comprobante,
                    Cedula_cliente = valor2.Cedula_cliente,
                    entregado = valor2.entregado
                };
                db.InsertRecord<Pedido>("Pedidos", valor);
            }

            //Adiciona una categoría en la tabla si no hay ningún otra con el mismo número de categoría
            //Ejemplo: localhost:1050/AddCategoria
            if (p.http_url == "/api/AddCategoria")
            {
                var valor2 = JsonSerializer.Deserialize<Categoria2>(data);
                var valor = new Categoria
                {
                    IdCategoria = valor2.IdCategoria,
                    Nombre = valor2.Nombre
                };
                db.InsertRecord<Categoria>("Categorias", valor);
            }

            //Actualiza un cliente y verifica con el número de cédula que se envía
            //Ejemplo: localhost:1050/UpdCliente
            if (p.http_url == "/api/UpdCliente")
            {
                var valor2 = JsonSerializer.Deserialize<Cliente2>(data);
                var valor = new Cliente
                {
                    Cedula = valor2.Cedula,
                    Usuario = valor2.Usuario,
                    Nombre = valor2.Nombre,
                    direccion = valor2.direccion,
                    dob = valor2.dob,
                    telefono = valor2.telefono,
                    SINPE = valor2.SINPE,
                    pass = valor2.pass,
                    pedidos = valor2.pedidos
                };
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Cliente>("Clientes");
                var filter = Builders<Cliente>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);             
                db.InsertRecord<Cliente>("Clientes", valor);
            }

            //Actualiza un productor y verifica con el número de cédula que se envía
            //Ejemplo: localhost:1050/UpdProductor
            if (p.http_url == "/api/UpdProductor")
            {
                var valor2 = JsonSerializer.Deserialize<Productor2>(data);
                var valor = new Productor
                {
                    Cedula = valor2.Cedula,
                    Nombre = valor2.Nombre,
                    direccion = valor2.direccion,
                    dob = valor2.dob,
                    telefono = valor2.telefono,
                    SINPE = valor2.SINPE,
                    productos = valor2.productos,
                    pedidos = valor2.pedidos
                };
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Productor>("Productores");
                var filter = Builders<Productor>.Filter.Eq(x => x.Cedula, valor.Cedula);
                collection.DeleteOne(filter);
                db.InsertRecord<Productor>("Productores", valor);
            }

            //Actualiza un pedido y verifica con el número de pedido
            //Ejemplo: localhost:1050/UpdPedido
            if (p.http_url == "/api/UpdPedido")
            {
                var valor2 = JsonSerializer.Deserialize<Pedido2>(data);
                var valor = new Pedido
                {
                    num_pedido = valor2.num_pedido,
                    productos = valor2.productos,
                    num_comprobante = valor2.num_comprobante,
                    Cedula_cliente = valor2.Cedula_cliente,
                    entregado = valor2.entregado
                };
                var client = new MongoClient();
                IMongoDatabase dba = client.GetDatabase("Mercadito");
                var collection = dba.GetCollection<Pedido>("Pedidos");
                var filter = Builders<Pedido>.Filter.Eq(x => x.num_pedido, valor.num_pedido);
                collection.DeleteOne(filter);
                db.InsertRecord<Pedido>("Pedidos", valor);
            }

            //Actualiza un categoría y verifica con el número de categoría
            //Ejemplo: localhost:1050/UpdCategoria
            if (p.http_url == "/api/UpdCategoria")
            {
                var valor2 = JsonSerializer.Deserialize<Categoria2>(data);
                var valor = new Categoria
                {
                    IdCategoria = valor2.IdCategoria,
                    Nombre = valor2.Nombre
                };
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
