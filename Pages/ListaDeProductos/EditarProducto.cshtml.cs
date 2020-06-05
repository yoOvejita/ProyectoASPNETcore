using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrimerVistazoASPNETcore.Model;

namespace PrimerVistazoASPNETcore.Pages.ListaDeProductos
{
    public class EditarProductoModel : PageModel
    {
        private MiDbContext DB;
        [BindProperty]
        public Producto Producto { get; set; }
        public EditarProductoModel(MiDbContext db) {
            DB = db;
        }
        public async Task OnGet(int id)
        {
            Producto = await DB.Producto.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                var ProductoDesdeLaDB = await DB.Producto.FindAsync(Producto.Id);
                ProductoDesdeLaDB.Nombre = Producto.Nombre;
                ProductoDesdeLaDB.Precio = Producto.Precio;
                await DB.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}