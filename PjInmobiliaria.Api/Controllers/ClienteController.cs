using Microsoft.AspNetCore.Mvc;
using PjInmobiliaria.Application.Dto_s.Request;
using PjInmobiliaria.Application.Interfaces;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;

namespace PjInmobiliaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication clienteApplication;
        public ClienteController(IClienteApplication _clienteApplication)
        {
            clienteApplication = _clienteApplication;
        }

        [HttpPost("ListarClientes")]
        public async Task<IActionResult> ListadoClientes([FromBody] BaseFilterRequest filter)
        {
            var response = await clienteApplication.ListaClientes(filter);
            return Ok(response);
        }

        //[HttpGet("Select")]
        //public async Task<IActionResult> ListadoSelectClientes()
        //{
        //    var response = await clienteApplication.ListaClientesCombo();
        //    return Ok(response);
        //}

        [HttpGet("ObtenerClienteByID/{id:int}")]
        public async Task<IActionResult> ObtenerClienteById(int id)
        {

            var response = await clienteApplication.ClienteById(id);
            return Ok(response);
        }

        [HttpPost("RegistrarCliente")]
        public async Task<IActionResult> RegistrarCliente([FromBody] ClienteDtoRequest clienteDto)
        {
            var response = await clienteApplication.RegistrarCliente(clienteDto);
            return Ok(response);
        }

        [HttpPut("EditarCliente/{id:int}")]
        public async Task<IActionResult> EditarCliente(int id, [FromBody] ClienteDtoRequest clienteDto)
        {
            var response = await clienteApplication.EditarCliente(id, clienteDto);
            return Ok(response);
        }

        [HttpDelete("BorrarCliente/{id:int}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var response = await clienteApplication.EliminarCliente(id);
            return Ok(response);
        }

    }
}
