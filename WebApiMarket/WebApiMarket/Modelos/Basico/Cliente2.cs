using System.Collections.Generic;
using WebApiMarket.Modelos;

namespace WebApiMarket.NormalModels
{
    public class Cliente2
    {   public string Cedula { get; set; }
        public string Usuario { get; set; }
        public List<string> Nombre { get; set; }
        public List<string> direccion { get; set; }
        public List<int> dob { get; set; }
        public string telefono { get; set; }
        public string SINPE { get; set; }
        public string pass { get; set; }
        public bool aceptado { get; set; }
        public List<int> pedidos { get; set; }
    }
}
