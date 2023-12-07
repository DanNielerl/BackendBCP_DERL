using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BCP_DERL.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public required string Paterno { get; set; }
        public required string Materno { get; set; }
        public required string Nombres { get; set; }
        public required string CI { get; set; }
        [DataType(DataType.Date)]
        public required DateTime FechaNacimiento { get; set; }
        public required string Genero { get; set; }
        public required int Celular { get; set; }
        [Precision(18, 2)] 
        public decimal NivelIngresos { get; set; }
        public required string Correo { get; set; }
        public required string Cuenta { get; set; }
        [DataType(DataType.Date)]
        public required DateTime FechaRegistro { get; set; }
        [DataType(DataType.Date)]
        public required DateTime FechaActualizacion { get; set; }
    }
}
