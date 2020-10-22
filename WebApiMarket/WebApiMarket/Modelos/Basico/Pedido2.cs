using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMarket.NormalModels
{
    public class Pedido2
    {
        public string numpedido { get; set; }
        public string monto { get; set; }
        public List<string> productos { get; set; }
        public List<string> cantproductos { get; set; }
        public string numcomprobante { get; set; }
        public string cedulacliente { get; set; }
        public bool entregado { get; set; }
    }
}
