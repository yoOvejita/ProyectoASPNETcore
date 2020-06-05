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

        public async Task<IActionResult> OnPostEliminar(int id)
        {
            var ProductoAeliminar = await DB.Producto.FindAsync(id);
            if (ProductoAeliminar == null)
                return NotFound();
            DB.Producto.Remove(ProductoAeliminar);
            await DB.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        //Con esto ya vimos el CRUD, pues creamos registros,los consultamos, los editamos y eliminamos
    }
}