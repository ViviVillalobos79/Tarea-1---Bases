namespace WebApiMarket.NormalModels
{
    class Producto2
    {
        public int Num_Producto { get; set; }
        public string Nombre { get; set; }
        public int id_categoria { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Modo_venta { get; set; }
        public bool Disponibilidad { get; set; }
        public int CedulaProductor { get; set; }
    }
}
