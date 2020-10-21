using Microsoft.AspNetCore.Mvc;
using WebApiMarket.Modelos;
using WebApiMarket.Repositorios;

namespace WebApiMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPClientes rpCli = new RPClientes();
            return Ok(rpCli.ObtenerClientes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPClientes rpCli = new RPClientes();

            var cliRet = rpCli.ObtenerCliente(id);

            if (cliRet == null)
            {
                var nf = NotFound("El cliente " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente(Client nuevoCliente)
        {
            RPClientes rpCli = new RPClientes();
            rpCli.Agregar(nuevoCliente);
            return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        }
    }
}