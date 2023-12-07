using Azure.Messaging;
using BCP_DERL.Data;
using BCP_DERL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace BCP_DERL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly DataContext _context;

        public CuentaController(DataContext context)
        {
            _context = context;
        }

        public class ResultadoCompuesto(Cliente clienteResultado, Cuenta? cuentaResultado)
        {

            public Cliente ClienteResultado { get; set; } = clienteResultado;
            public Cuenta? CuentaResultado { get; set; } = cuentaResultado;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> ReporteCuentas()
        {
            /* var cuentas = new List<Cuenta>
            {
                new Cuenta
                {
                    Id = 1,
                    TipoCuenta = "Ahorros",
                    Saldo = 15,
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    ClienteId = 1
                }
            };*/

            var cuentas = await _context.Cuentas.ToListAsync();

            return Ok(cuentas);
        }

        [HttpGet]
        [Route("CuentasDeCliente/{ClienteID}")]
        public async Task<ActionResult<List<Cuenta>>> CuentasDeClienteId(int ClienteId)
        {
            var cuentas = await _context.Cuentas.FindAsync(ClienteId);
            if (cuentas is null)
                return BadRequest("Cliente sin cuentas");

            return Ok(cuentas);
        }

        [HttpGet]
        [Route("ClientePorCI/{CI}")]
        public async Task<IResult> ClientePorCI(int CI)
        { 
            var cliente = await _context.Clientes.FindAsync(CI);
            if (cliente is null) {
                return Results.BadRequest("No existe cliente");
            }
            var cuenta = await _context.Cuentas.FindAsync(cliente.Id);
            ResultadoCompuesto objetoResultado = new(cliente, cuenta);
            return Results.Ok(cliente);
        }
    }
}
