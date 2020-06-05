using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrimerVistazoASPNETcore.Pages
{
    public class EjemploMultiSubmitModel : PageModel
    {
        public void OnGet()
        {

        }
        //Los métodos por post deben tener siempre, en su nombre, el texto "OnPost"
        //lo que le continúa es el nombre distintivo de cada método POST.

        public void OnPostTarea1() { 

        }

        public void OnPostTarea2()
        {

        }
    }
}