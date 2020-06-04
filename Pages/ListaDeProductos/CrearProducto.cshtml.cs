using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrimerVistazoASPNETcore.Model;

namespace PrimerVistazoASPNETcore.Pages.ListaDeProductos
{
    public class CrearProductoModel : PageModel
    {
        private readonly MiDbContext DB;
        [BindProperty]
        public Producto Producto { get; set; }
        public CrearProductoModel(MiDbContext db) {
            DB = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                await DB.Producto.AddAsync(Producto);
                await DB.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else {
                return Page();
            }
        }
    }
}