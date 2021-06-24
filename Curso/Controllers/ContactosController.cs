using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.Data.UoW;
using Curso.Domains.Contracts;

namespace Curso.Controllers {
    public class ContactosController : Controller {
        private readonly IContactoService srv;

        public ContactosController(IContactoService srv) {
            this.srv = srv;
        }

        // GET: Contactos
        public IActionResult Index() {
            return View(srv.GetAll());
        }

        // GET: Contactos/Details/5
        public IActionResult Details(int? id, string mode) {
            if (id == null) {
                return NotFound();
            }

            var contacto = srv.GetOne(id);
            if (contacto == null) {
                return NotFound();
            }

            if (mode == "short")
                return View("DetailsCorta", contacto);
            else
                return View(contacto);
        }

        // GET: Contactos/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tratamiento,Nombre,Apellidos,Correo,FNacimiento,Activo")] Contacto contacto) {
            if (ModelState.IsValid) {
                srv.Create(contacto);
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var contacto = srv.GetOne(id);
            if (contacto == null) {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tratamiento,Nombre,Apellidos,Correo,FNacimiento,Activo")] Contacto contacto) {
            if (id != contacto.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    srv.Modify(id, contacto);
                    return RedirectToAction(nameof(Index));
                } catch (DbUpdateConcurrencyException) {
                    if (srv.GetOne(contacto.Id) == null) {
                        return NotFound();
                    } else {
                        throw;
                    }
                } catch(Exception ex) {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var contacto = srv.GetOne(id);
            if (contacto == null) {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            srv.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DetailsPartial() {
            //if (id == null) {
            //    return NotFound();
            //}

            var contacto = srv.GetOne(1);
            if (contacto == null) {
                return NotFound();
            }

            return PartialView("DetailsCorta", contacto);
        }

    }
}
