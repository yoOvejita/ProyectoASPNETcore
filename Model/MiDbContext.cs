using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerVistazoASPNETcore.Model
{
    public class MiDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }
        public MiDbContext(DbContextOptions<MiDbContext> opciones) : base(opciones)
        {

        }
    }
}
