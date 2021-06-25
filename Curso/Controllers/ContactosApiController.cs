using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Curso.Domains.Entities;
using Curso.Infraestructure.Data.UoW;

namespace Curso.Controllers
{
    [Route("api/contactos")]
    [ApiController]
    public class ContactosApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactosApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto(int page=0, int rows=10)
        {
            return await _context.Contacto.Skip(page*rows).Take(rows).ToListAsync();
        }
        [HttpGet("count")]
        public ActionResult<int> GetCount() {
            return _context.Contacto.Count();
        }

        // GET: api/ContactosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var contacto = await _context.Contacto.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        // PUT: api/ContactosApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactosApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contacto.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacto", new { id = contacto.Id }, contacto);
        }

        // DELETE: api/ContactosApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
