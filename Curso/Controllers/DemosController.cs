using Curso.Domains.Services;
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
            //this.ViewData["cuantos"] = 5;
            this.ViewBag.cuantos = 5;
            return this.View();
            //return this.Content("Hola mundo");
        }
        public IActionResult Saluda(string id) {
            return this.Content("Hola " + id);
        }
        //[ActionName("alternativo")]
        public IActionResult Cortes(string id, string que, [Bind("dices")] string hago) {
            return this.Content(que + " " + hago + " " + id);
        }

        [NonAction]
        public IActionResult Despide() {
            return this.Content("Adios mundo");
        }
        [Route("{id}/persona")] 
        public IActionResult Contacto() {
            var srv = new ContactoMOCKService();
            var c = srv.Get(1);
            return this.Json(c); // this.Content($"Hola {c.Nombre} {c.Apellidos}");
        }

        private string memo = "inicia";
        public IActionResult pon(string id) {
            memo = id;
            return this.Content($"he guardado {memo}");
        }
        public IActionResult dame(string id) {
            return this.Content($"tengo {memo}");
        }
    }
}
