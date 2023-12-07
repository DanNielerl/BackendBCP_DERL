using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BCP_DERL.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        [Precision(18, 2)] 
        public decimal Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public required string TipoCuenta { get; set; }
        public int ClienteId { get; set; }
    }
}
