using Curso.Domains.Contracts;
using Curso.Domains.Entities;
using Curso.Infraestructure.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infraestructure.Data.Repositories {
    public class ContactoRepository : IContactoRepository {
        private readonly ApplicationDbContext _context;

        public ContactoRepository(ApplicationDbContext context) {
            _context = context;
        }

        public List<Contacto> GetAll() {
            return _context.Contacto.ToList();
        }

        public Contacto GetOne(int? id) {
            return _context.Contacto
              .FirstOrDefault(m => m.Id == id);
        }

        public void Create(Contacto contacto) {
            _context.Add(contacto);
            _context.SaveChanges();
        }

        public void Modify(int id, Contacto contacto) {
            _context.Update(contacto);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var contacto = _context.Contacto.Find(id);
            _context.Contacto.Remove(contacto);
            _context.SaveChanges();
        }
    }
    public class ContactoMockRepository : IContactoRepository {
        private readonly ApplicationDbContext _context;

        public ContactoMockRepository(ApplicationDbContext context) {
            _context = context;
        }

        public List<Contacto> GetAll() {
            var rslt = new List<Contacto>();
            rslt.Add(GetOne(1));
            rslt.Add(GetOne(2));
            return rslt;
        }

        public Contacto GetOne(int? id) {
            return new Contacto() {
                Id = id.Value, Nombre = "Pepito " + id.Value,
                Apellidos = "Grillo" + id.Value, Correo = "pgrillo@kk.kk"
            };
        }

        public void Create(Contacto contacto) {
        }

        public void Modify(int id, Contacto contacto) {
            if (id == 1)
                throw new Exception("Probar excepción");
        }

        public void Delete(int id) {
        }
    }
}
