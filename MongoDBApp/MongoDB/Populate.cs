using System;
using System.Collections.Generic;
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
        new List<string> usuarios = new List<string> { };

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

                var contra = contra_usuario_Ran();
                var celular = celular_SINPE_Ran();
                var SINPEA = celular_SINPE_Ran();
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
                    pass = contra

                };
            }




        }



    }
}
