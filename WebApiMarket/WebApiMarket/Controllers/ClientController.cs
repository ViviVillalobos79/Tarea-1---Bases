using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiMarket.DB;
using WebApiMarket.NormalModels;
using WebApiMarket.Repositorios;

namespace WebApiMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        MongoCRUD db = new MongoCRUD("Mercadito");  //Se obtiene la base que se va a estar usando

        [HttpGet]
        public IActionResult Get()
        {

            var recs = db.LoadRecords<Cliente>("Clientes");
            var clientes2 = new List<Cliente2> { };
            foreach (var cliente in recs)
            {
                var cliente2 = new Cliente2
                {
                    Cedula = cliente.Cedula.ToString(),
                    Usuario = cliente.Usuario,
                    Nombre = cliente.Nombre,
                    direccion = cliente.direccion,
                    dob = cliente.dob,
                    telefono = cliente.telefono.ToString(),
                    SINPE = cliente.SINPE.ToString(),
                    pass = cliente.pass,
                    aceptado = cliente.aceptado,
                    pedidos = cliente.pedidos
                };

                clientes2.Add(cliente2);

            }
            
            return Ok(clientes2);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente(Cliente2 nuevoCliente)
        {
            System.Diagnostics.Debug.WriteLine(nuevoCliente);
            Console.WriteLine(nuevoCliente);
            RPClientes rpCli = new RPClientes();
            rpCli.Agregar2(nuevoCliente);
            return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        }

        [HttpGet("Usuario/{username}/{password}")]
        public IActionResult AuthClient(string username, string password)
        {
            RPClientes rpCli = new RPClientes();
            var cliente = rpCli.auth(username, password);

            return Ok(cliente);
        }



    }
}
