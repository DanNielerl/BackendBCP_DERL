using BCP_DERL.Models;
using Microsoft.EntityFrameworkCore;

namespace BCP_DERL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
