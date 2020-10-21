using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiMarket.DB;
using WebApiMarket.NormalModels;
using WebApiMarket.Repositorios;

namespace WebApiMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductorController : ControllerBase
    {
        MongoCRUD db = new MongoCRUD("Mercadito");

        [HttpGet]
        public IActionResult Get()
        {

            var recs = db.LoadRecords<Productor>("Clientes");
            var productores2 = new List<Productor2> { };
            //foreach (var cliente in recs)
            //{
            //    var cliente2 = new Cliente2
            //    {
            //        Cedula = cliente.Cedula.ToString(),
            //        Usuario = cliente.Usuario,
            //        Nombre = cliente.Nombre,
            //        direccion = cliente.direccion,
            //        dob = cliente.dob,
            //        telefono = cliente.telefono.ToString(),
            //        SINPE = cliente.SINPE.ToString(),
            //        pass = cliente.pass,
            //        aceptado = cliente.aceptado,
            //        pedidos = cliente.pedidos
            //    };

            //    clientes2.Add(cliente2);

            //}

            //return Ok(clientes2);
            return Ok();
        }


    }
}
