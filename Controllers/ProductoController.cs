using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerVistazoASPNETcore.Model;

namespace PrimerVistazoASPNETcore.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly MiDbContext DB;

        public ProductoController(MiDbContext db) {
            DB = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Json(new { data = await DB.Producto.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ProductoActual = await DB.Producto.FirstOrDefaultAsync(elem => elem.Id == id);
            if (ProductoActual == null) {
                return Json(new { success = false, mensaje = "Error al intentar eliminar el registro"});
            }
            DB.Producto.Remove(ProductoActual);
            await DB.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Se eliminó el registro" });
        }
    }
}
