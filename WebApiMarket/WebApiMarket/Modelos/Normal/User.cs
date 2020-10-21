using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMarket.Modelos.Normal
{
    public class User
    {
        public string cedula { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public bool aceptado { get; set; }
        public bool login { get; set; }
        public string rol { get; set; }
    }
}
