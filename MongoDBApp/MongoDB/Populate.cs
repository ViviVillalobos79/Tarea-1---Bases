using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MongoDB
{
    class Populate
    {
        MongoCRUD db = new MongoCRUD("Mercadito");

        public List<string> nombres = new List<string> {
                "Viviana", "Natalia", "Lucía", "María", "Maesly", "Pablo",
                "Estebas", "Enrique", "Nickolás", "Mario", "Juan", "Camila",
                "Andrea", "Bryan", "Diego", "Daniela", "Daniel", "Josué",
                "Joshua", "Celeste", "Rosa", "Julián", "Aaron", "Laura", "Cecilia",
                "Lucía", "Gabriela", "Sebastián", "Carlos", "Carolina", "Alberto", "Ligia",
                "Jenny", "Thomás", "Franco", "José", "Jose", "Alfredo", "Roberto", "Francisco",
                "Isabella", "Isabel"
            };

        public List<string> apellidos = new List<string>
            {
                "Villalobos", "Valverde", "Monge", "Golcher",
                "Azofeifa", "González", "Velásquez", "Bone", "Rodiguez",
                "Cordero", "Solano", "Guillén", "Chavez", "Chavarría",
                "Mora", "Solorzano", "Vargas", "Acuña", "Roldán", "Gutierrez",
                "Cubero", "Montero", "Guzman", "Quesada", "Solís", "Alba", "Fernandez",
                "Hernandez", "Castillo", "Castrillo", "Gamboa", "Noguera", "Leitón"
            };

        new List<Direccion> direcciones = new List<Direccion>
            {
                new Direccion
                {
                    Provincia = "San José",
                    Canton = "San José",
                    Distrito = "Pavas"
                },
                new Direccion
                {
                    Provincia = "San José",
                    Canton = "San José",
                    Distrito = "Zapote"
                },
                new Direccion
                {
                    Provincia = "San José",
                    Canton = "Tibás",
                    Distrito = "San Juán"
                },
                new Direccion
                {
                    Provincia = "Alajuela",
                    Canton = "Alajuela",
                    Distrito = "Sabanilla"
                },
                new Direccion
                {
                    Provincia = "Alajuela",
                    Canton = "Grecia",
                    Distrito = "Tacares"
                },
                new Direccion
                {
                    Provincia = "Alajuela",
                    Canton = "Atenas",
                    Distrito = "Escobal"
                },
                new Direccion
                {
                    Provincia = "Cartago",
                    Canton = "Cartago",
                    Distrito = "Dulce Nombre"
                },
                new Direccion
                {
                    Provincia = "Cartago",
                    Canton = "La Unión",
                    Distrito = "Concepción"
                },
                new Direccion
                {
                    Provincia = "Cartago",
                    Canton = "Oreamuno",
                    Distrito = "San Rafael"
                },
                new Direccion
                {
                    Provincia = "Heredia",
                    Canton = "Heredia",
                    Distrito = "Ulloa"
                },
                new Direccion
                {
                    Provincia = "Heredia",
                    Canton = "Barva",
                    Distrito = "San Pedro"
                },
                new Direccion
                {
                    Provincia = "Limón",
                    Canton = "Limón",
                    Distrito = "Río Blanco"
                },


            };
        new List<int> cedulas = new List<int> { };
        new List<int> productos = new List<int> { };
        new List<int> pedidos = new List<int> { };
        new List<List<string>> productos_pro = new List<List<string>>
        {   new List<string>
            {"Tomate", "Kale", "Espinaca", "Cebolla", "Chile" },
            new List<string>
            {"Yogur", "Natilla", "Cuajada", "Leche", "Queso", "Mantequilla" },
            new List<string>
            {"Alfalfa", "Frijol", "Judías verdes", "Garbanzos", "Lentejas", "Maní" },
            new List<string>
            {"Fresa", "Limón", "Naranja", "Mandarina", "Melón", "Piña" },
            new List<string>
            {"Camote", "Papa", "Cúrcuma", "Jengibre", "Nabo", "Yuca" }

        };
        new List<string> usuarios = new List<string> { };
        new List<string> por_venta = new List<string> { "kilo", "paquete", "caja"};
        new List<Categoria> categorias = new List<Categoria> 
        { 
            new Categoria
            {
                IdCategoria = 1,
                Nombre = "Verduras"
            },
            new Categoria
            {
                IdCategoria = 2,
                Nombre = "Lácteos"
            },
            new Categoria
            {
                IdCategoria = 3,
                Nombre = "Legumbres"
            },
            new Categoria
            {
                IdCategoria = 4,
                Nombre = "Frutas"
            },
            new Categoria
            {
                IdCategoria = 5,
                Nombre = "Tubérculos"
            },

        };

        public string contra_usuario_Ran()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            var longitud = caracteres.Length;
            var longi_contra = 10;
            var contra = string.Empty;

            for (int i = 0; i < longi_contra; i++)
            {
                char letra = caracteres[random.Next(longitud)];
                contra += letra.ToString();
            }
            return contra;
        }

        public int cedula_Ran()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var longi_ced = 9;
            var cedula = string.Empty;

            for (int i = 0; i < longi_ced; i++)
            {
                cedula += random.Next(0, 10).ToString();
            }
            return int.Parse(cedula);
        }

        public int celular_SINPE_Ran()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var longi_num = 7;
            var num = "8";

            for (int i = 0; i < longi_num; i++)
            {
                num += random.Next(0, 10).ToString();
            }
            return int.Parse(num);
        }

        public List<int> genPedidos()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            var cantidad = random.Next(1, 16);
            var pedidos_usuario = new List<int> { };
            for (int i = 0; i < cantidad; i++)
            {
                var numero = random.Next(0, 1589739);
                while (pedidos.Contains(numero))
                {
                    numero = random.Next(0, 999999999);
                }
                pedidos.Add(numero);
                pedidos_usuario.Add(numero);

            }
            return pedidos_usuario;

        }

        public List<int> genProductos()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            var cantidad = random.Next(1, 16);
            var productos_productor = new List<int> { };
            for (int i = 0; i < cantidad; i++)
            {
                var numero = random.Next(0, 1589739);
                while (productos.Contains(numero))
                {
                    numero = random.Next(0, 999999999);
                }
                productos.Add(numero);
                productos_productor.Add(numero);

            }
            return productos_productor;

        }

        public List<int> asingPedidos()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            var cantidad = random.Next(0, pedidos.Count);
            var pedidos_usuario = new List<int> { };
            if (cantidad != 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    var numero = random.Next(0, pedidos.Count);
                    var num_pedido = pedidos[numero];
                    pedidos.Remove(numero);
                    pedidos_usuario.Add(numero);

                }
            }
            return pedidos_usuario;
        }


        public void crear_productos(int cedula, List<int> productosA)
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            foreach (var num_producto in productosA)
            {                
                var categ = random.Next(1, 6);

                var nombre = productos_pro[categ - 1][random.Next(productos_pro[1].Count)];



                Producto producto = new Producto
                {
                    Num_Producto = num_producto,
                    Nombre = nombre,
                    id_categoria = categ,
                    Precio = random.Next(500, 18795),
                    Cantidad = random.Next(10, 90),
                    Modo_venta = por_venta[random.Next(por_venta.Count)],
                    Disponibilidad = true,
                    CedulaProductor = cedula
                };

                db.InsertRecord<Producto>("Productos", producto);

            }
        }

        public void crear_pedidos(int cedula, List<int> pedidosA)
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            foreach (var num_pedido in pedidosA)
            {
                var categ = random.Next(1, 6);
                var cantidad = random.Next(0, 10);
                var productos_cliente = new List<int> { };
                for (int i = 0; i < cantidad; i++)
                {
                    productos_cliente.Add(productos[random.Next(productos.Count)]);
                }

                Pedido ped = new Pedido
                {
                    num_pedido = num_pedido,
                    productos = productos_cliente,
                    num_comprobante = random.Next(0, 28712),
                    Cedula_cliente = cedula,
                    entregado = false
            };

                db.InsertRecord<Pedido>("Pedidos", ped);

            }
        }
        
        public Populate()
        {
        }

        public void clientes()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            for (int i = 0; i < 100; i++)
            {
                var cedula = cedula_Ran();
                while (cedulas.Contains(cedula))
                {
                    cedula = cedula_Ran();
                }
                cedulas.Add(cedula);

                var usuario = contra_usuario_Ran();
                while (usuarios.Contains(usuario))
                {
                    usuario = contra_usuario_Ran();
                }
                usuarios.Add(usuario);

                var pedidosA = genPedidos();
                var contra = contra_usuario_Ran();
                var celular = celular_SINPE_Ran();
                var SINPEA = celular_SINPE_Ran();
                crear_pedidos(cedula, pedidosA);
                var nombre = new Nombre_Persona
                {
                    Primer_Nombre = nombres[random.Next(nombres.Count)],
                    Apellido1 = apellidos[random.Next(apellidos.Count)],
                    Apellido2 = apellidos[random.Next(apellidos.Count)]
                };
                var dobs = new DOB
                {
                    Dia = random.Next(1, 27),
                    Mes = random.Next(1, 13),
                    Year = random.Next(1950, 2016)
                };

                var cliente = new Cliente
                {
                    Cedula = cedula,
                    Usuario = usuario,
                    Nombre = nombre,
                    direccion = direcciones[random.Next(direcciones.Count)],
                    dob = dobs,
                    telefono = celular,
                    SINPE = SINPEA,
                    pass = contra,
                    pedidos = pedidosA                    

                };

                db.InsertRecord<Cliente>("Clientes", cliente);
            }




        }


        public void productores()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            for (int i = 0; i < 100; i++)
            {
                var cedula = cedula_Ran();
                while (cedulas.Contains(cedula))
                {
                    cedula = cedula_Ran();
                }
                cedulas.Add(cedula);

                var pedidosA = asingPedidos();
                var celular = celular_SINPE_Ran();
                var SINPEA = celular_SINPE_Ran();
                crear_productos(cedula, pedidosA);

                var nombre = new Nombre_Persona
                {
                    Primer_Nombre = nombres[random.Next(nombres.Count)],
                    Apellido1 = apellidos[random.Next(apellidos.Count)],
                    Apellido2 = apellidos[random.Next(apellidos.Count)]
                };
                var dobs = new DOB
                {
                    Dia = random.Next(1, 27),
                    Mes = random.Next(1, 13),
                    Year = random.Next(1950, 2016)
                };

                var productor = new Productor
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    direccion = direcciones[random.Next(direcciones.Count)],
                    dob = dobs,
                    telefono = celular,
                    SINPE = SINPEA,
                    productos = genProductos(),
                    pedidos = pedidosA

                };

                db.InsertRecord<Productor>("Productores", productor);
            }




        }



        public void cateogiasA()
        {
            foreach(Categoria cate in categorias){
                db.InsertRecord<Categoria>("Categorias", cate);
            }
        }





    }
}
