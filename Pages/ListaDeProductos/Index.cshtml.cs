using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrimerVistazoASPNETcore.Model;

namespace PrimerVistazoASPNETcore.Pages.ListaDeProductos
{
    public class IndexModel : PageModel
    {
        private readonly MiDbContext DB;
        public IEnumerable<Producto> Productos { get; set; }
        public IndexModel(MiDbContext db) {
            DB = db;
        }
        public async Task OnGet()
        {
            Productos = await DB.Producto.ToListAsync();
        }
    }
}