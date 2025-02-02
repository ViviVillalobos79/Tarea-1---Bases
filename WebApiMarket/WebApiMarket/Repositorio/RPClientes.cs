﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiMarket.DB;
using WebApiMarket.Modelos;
using WebApiMarket.Modelos.Normal;
using WebApiMarket.NormalModels;

namespace WebApiMarket.Repositorios
{
    public class RPClientes
    {
        MongoCRUD db = new MongoCRUD("Mercadito");
        public static List<Client> _listaClientes = new List<Client>()
        {
            new Client() { Id = 1, Nombre = "Cliente 1" , Apellido = "Apellido 1" },
            new Client() { Id = 2, Nombre = "Cliente 2" , Apellido = "Apellido 2" },
            new Client() { Id = 3, Nombre = "Cliente 3" , Apellido = "Apellido 3" }
        };

        public static List<Cliente2> _clientes2 = new List<Cliente2> { };
        public static Cliente2 _cliente2 = new Cliente2();
        public static string name;

    public IEnumerable<Client> ObtenerClientes()
        {
            return _listaClientes;
        }

        public Client ObtenerCliente(int id)
        {
            var client = _listaClientes.Where(cli => cli.Id == id);

            return client.FirstOrDefault();
        }

        public void Agregar(Client nuevoClient)
        {
            
            _listaClientes.Add(nuevoClient);
            //db.InsertRecord<Cliente>("Clientes", valor);

        }

        public void Agregar2(Cliente2 nuevoClient)
        {
            _cliente2 = nuevoClient;
            var cliente = new Cliente()
            {
                Cedula = int.Parse(_cliente2.Cedula),
                Usuario = _cliente2.Usuario,
                Nombre = _cliente2.Nombre,
                direccion = _cliente2.direccion,
                dob = _cliente2.dob,
                telefono = int.Parse(_cliente2.telefono),
                SINPE = int.Parse(_cliente2.SINPE),
                pass = _cliente2.pass,
                aceptado = _cliente2.aceptado,
                pedidos = _cliente2.pedidos
            };
            _clientes2.Add(nuevoClient);
            db.InsertRecord<Cliente>("Clientes", cliente);

        }

        public List<Cliente2> getAllClientes()
        {
            var clientes = db.LoadRecords<Cliente>("Clientes");
            var clientes2 = new List<Cliente2> { };
            foreach (var cliente in clientes)
            {
                var cliente2 = new Cliente2
                {
                    Cedula = cliente.Cedula.ToString(),
                    Usuario = cliente.Usuario,
                    Nombre = cliente.Nombre,
                    direccion = cliente.direccion,
                    dob = cliente.dob,
                    telefono = cliente.telefono.ToString(),
                    SINPE = cliente.SINPE.ToString(),
                    pass = cliente.pass,
                    aceptado = cliente.aceptado,
                    pedidos = cliente.pedidos
                };

                clientes2.Add(cliente2);

            }

            return clientes2;
        }
        public List<Productor2> getAllProductores()
        {
            var productores = db.LoadRecords<Productor>("Productores");
            var productores2 = new List<Productor2> { };
            foreach (var productor in productores)
            {
                var productor2 = new Productor2
                {
                    cedula = productor.Cedula.ToString(),
                    usuario = productor.Usuario,
                    nombre = productor.Nombre,
                    direccion = productor.direccion,
                    dob = productor.dob,
                    telefono = productor.telefono.ToString(),
                    SINPE = productor.SINPE.ToString(),
                    pass = productor.pass,
                    aceptado = productor.aceptado,
                    productos = productor.productos,
                    pedidos = productor.pedidos
                };

                productores2.Add(productor2);

            }

            return productores2;
        }

        public List<Producto2> getAllProductos()
        {
            var productos = db.LoadRecords<Producto>("Productos");
            var productos2 = new List<Producto2> { };
            foreach (var producto in productos)
            {
                var producto2 = new Producto2
                {
                    numproducto = producto.Num_Producto,
                    nombre = producto.Nombre,
                    idcategoria = producto.id_categoria,
                    precio = producto.Precio,
                    cantidad = producto.Cantidad,
                    modoventa = producto.Modo_venta,
                    disponibilidad = producto.Disponibilidad,
                    cedulaproductor = producto.CedulaProductor

                };

                productos2.Add(producto2);

            }

            return productos2;
        }

        public User auth(string username, string password)
        {
            var clientes = getAllClientes();
            var cliente = new Cliente2();
            foreach(var rec in clientes)
            {
                if (rec.Usuario == username)
                {
                    cliente = rec;

                }
            }

            var usuario = new User
            {
                cedula = cliente.Cedula,
                usuario = cliente.Usuario,
                pass = cliente.pass,
                aceptado = cliente.aceptado,
                login = (cliente.pass == password),
                rol = "Cliente"
            };

            return usuario;
        }

        public void AgregarPedido(Pedido2 pedido)
        {
            
            var pedidoNuevo = new Pedido()
            {
                num_pedido = pedido.numpedido,
                monto =pedido.monto,
                productos = pedido.productos,
                cantproductos = pedido.cantproductos,
                numcomprobante = pedido.numcomprobante,
                cedulacliente = pedido.cedulacliente,
                entregado = pedido.entregado
            };
            
            db.InsertRecord<Pedido>("Pedidos", pedidoNuevo);

        }

        public void AgregarCategoria(Categoria2 categoria)
        {

            var categoria1 = new Categoria()
            {
                idcategoria = categoria.idcategoria,
                nombre = categoria.nombre
            };

            db.InsertRecord<Categoria>("Categoria", categoria1);

        }
    }
}