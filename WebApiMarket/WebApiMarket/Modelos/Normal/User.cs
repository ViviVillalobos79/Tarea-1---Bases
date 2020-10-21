using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMarket.Modelos.Normal
{
    public class User
    {
        public string Cedula { get; set; }
        public string Usuario { get; set; }
        public string pass { get; set; }
        public bool aceptado { get; set; }
        public bool login { get; set; }
    }
}
