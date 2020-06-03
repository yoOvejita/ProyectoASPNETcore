using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerVistazoASPNETcore.Model
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public float Precio { get; set; }
    }
}
