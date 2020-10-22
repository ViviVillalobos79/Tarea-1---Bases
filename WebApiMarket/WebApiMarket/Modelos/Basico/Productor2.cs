using System;
using System.Collections.Generic;
using System.Text;
using WebApiMarket.Modelos;

namespace WebApiMarket.NormalModels
{
    public class Productor2
    {
        public string cedula { get; set; }
        public string usuario { get; set; }
        public List<string> nombre { get; set; } //[Nombre, Apellido1, Apellido2]
        public List<string> direccion { get; set; } //[Provincia, Cantón, Distrito]
        public List<int> dob { get; set; } //[Dia, Mes, Año]
        public string telefono { get; set; }
        public string SINPE { get; set; }
        public string pass { get; set; }
        public bool aceptado { get; set; }
        public List<int> productos { get; set; }
        public List<int> pedidos { get; set; }
    }
}
