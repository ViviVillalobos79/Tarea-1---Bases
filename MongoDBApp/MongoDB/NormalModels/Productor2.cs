using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.NormalModels
{
    class Productor2
    {
        public int Cedula { get; set; }
        public Nombre_Persona Nombre { get; set; }
        public Direccion direccion { get; set; }
        public DOB dob { get; set; }
        public int telefono { get; set; }
        public int SINPE { get; set; }
        public List<int> productos { get; set; }
        public List<int> pedidos { get; set; }
    }
}
