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
                    cedula = productor.Cedula.ToString(),
                    usuario = productor.Usuario,
                    nombre = productor.Nombre,
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
                Cedula = int.Parse(nuevoProductor.cedula),
                Usuario = nuevoProductor.usuario,
                Nombre = nuevoProductor.nombre,
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
                if (rec.usuario == username)
                {
                    productor = rec;

                }
            }

            var usuario = new User
            {
                cedula = productor.cedula,
                usuario = productor.usuario,
                pass = productor.pass,
                aceptado = productor.aceptado,
                login = (productor.pass == password),
                rol = "Productor"
            };

            return Ok(usuario);
        }


        [HttpGet("Direccion/{provincia}/{canton}/{distrito}")]
        public IActionResult GetPDireccion(string provincia, string canton, string distrito)
        {
            RPClientes rpCli = new RPClientes();
            var productores2 = rpCli.getAllProductores();
            var productores = new List<Productor2> { };

            var direccion = new List<string> {provincia,canton,distrito};

            foreach (var rec in productores2)
            {
                if (rec.direccion[0] == provincia)
                {
                   if (rec.direccion[1] == canton)
                    {
                        if(rec.direccion[2] == distrito)
                        {
                            productores.Add(rec);
                        }
                    }
                    
                }
            }

            return Ok(productores);
        }

        [HttpGet("Cedula/{cedula}")]
        public IActionResult GetPCedula(string cedula)
        {
            RPClientes rpCli = new RPClientes();
            var productores = rpCli.getAllProductores();
            var productor = new Productor2();
            foreach (var rec in productores)
            {
                if (rec.cedula == cedula)
                {
                    productor = rec;
                }
            }

            return Ok(productor);
        }


    }
}
