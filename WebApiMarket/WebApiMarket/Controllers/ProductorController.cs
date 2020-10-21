using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiMarket.DB;
using WebApiMarket.Modelos.Normal;
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

            var recs = db.LoadRecords<Productor>("Productores");
            var productores2 = new List<Productor2> { };
            foreach (var productor in recs)
            {
                var productor2 = new Productor2
                {
                    Cedula = productor.Cedula.ToString(),
                    Usuario = productor.Usuario,
                    Nombre = productor.Nombre,
                    direccion = productor.direccion,
                    dob = productor.dob,
                    telefono = productor.telefono.ToString(),
                    SINPE = productor.SINPE.ToString(),
                    pass = productor.pass,
                    aceptado = productor.aceptado,
                    productos = productor.productos,
                    pedidos = productor.pedidos
                };

                productores2.Add(productor2);

            }

            return Ok(productores2);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarProductor(Productor2 nuevoProductor)
        {
            var productor = new Productor()
            {
                Cedula = int.Parse(nuevoProductor.Cedula),
                Usuario = nuevoProductor.Usuario,
                Nombre = nuevoProductor.Nombre,
                direccion = nuevoProductor.direccion,
                dob = nuevoProductor.dob,
                telefono = int.Parse(nuevoProductor.telefono),
                SINPE = int.Parse(nuevoProductor.SINPE),
                pass = nuevoProductor.pass,
                aceptado = nuevoProductor.aceptado,
                productos = nuevoProductor.productos,
                pedidos = nuevoProductor.pedidos
                
            };
            db.InsertRecord<Productor>("Productores", productor);
            return CreatedAtAction(nameof(AgregarProductor), nuevoProductor);
        }

        [HttpGet("Usuario/{username}/{password}")]
        public IActionResult AuthProductor(string username, string password)
        {
            RPClientes rpCli = new RPClientes();
            var productores2 = rpCli.getAllProductores();
            var productor = new Productor2();
            foreach (var rec in productores2)
            {
                if (rec.Usuario == username)
                {
                    productor = rec;

                }
            }

            var usuario = new User
            {
                Cedula = productor.Cedula,
                Usuario = productor.Usuario,
                pass = productor.pass,
                aceptado = productor.aceptado,
                login = (productor.pass == password),
                rol = "Productor"
            };

            return Ok(usuario);
        }


    }
}
