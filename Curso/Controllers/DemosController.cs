using Curso.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Controllers {
    public class DemosController : Controller {
        public IActionResult Index() {
            this.ViewData["msg"] = "Hola mundo";
            this.ViewData["cuantos"] = 5;
            return this.View();
            //return this.Content("Hola mundo");
        }
        public IActionResult Saluda(string id) {
            return this.Content("Hola " + id);
        }

        public IActionResult Despide() {
            return this.Content("Adios mundo");
        }
        public IActionResult Contacto() {
            var srv = new ContactoService();
            var c = srv.Get(1);
            return this.Content($"Hola {c.Nombre} {c.Apellidos}");
        }
    }
}
