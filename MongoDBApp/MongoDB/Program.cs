using System;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {


            MongoCRUD db = new MongoCRUD("FoodGos"); //I doesnt exist then is create
                                                    /////////// EJEMPLO de como insertar 
            db.InsertRecord("Clientes", new Cliente
            {
                Cedula = "117480511",
                Nombre = new Nombre_Persona { Primer_Nombre = "Maesly", Apellido1 = "Villalobos", Apellido2 = "Valverde" },
                direccion = new Direccion { Provincia = "San Jose", Canton = "San Jose", Distrito = "Hatillo" },
                dob = new DOB { Dia = "10", Mes = "07", Year = "1999" },
                telefono = "61682819",
                pass = "hola123"
            }); //Lo convierte en JSON y lo mete, pero se llama BSON
            Console.ReadLine();
        }
    }
}
