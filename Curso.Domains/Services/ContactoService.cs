using Curso.Domains.Contracts;
using Curso.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Domains.Services {
    public class ContactoService : IContactoService {
        IContactoRepository repository;
        public ContactoService(IContactoRepository repository) {
            this.repository = repository;
        }
        public List<Contacto> GetAll() {
            return repository.GetAll();
        }

        public Contacto GetOne(int? id) {
            return repository.GetOne(id);
        }

        public void Create(Contacto contacto) {
            if (contacto.EsInvalido())
                throw new Exception("Datos inválidos");
            repository.Create(contacto);
        }

        public void Modify(int id, Contacto contacto) {
            if (contacto.EsInvalido())
                throw new Exception("Datos inválidos");
            repository.Modify(id, contacto);
        }

        public void Delete(int id) {
            repository.Delete(id);
        }
    }

    public class ContactoMOCKService : IContactoService {
        public void Create(Contacto contacto) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Contacto Get(int id) {
            return new Contacto() {
                Id = id, Nombre = "Pepito",
                Apellidos = "Grillo", Correo = "pgrillo@kk.kk"
            };
        }

        public List<Contacto> GetAll() {
            throw new NotImplementedException();
        }

        public Contacto GetOne(int? id) {
            return new Contacto() {
                Id = id.Value, Nombre = "Pepito",
                Apellidos = "Grillo", Correo = "pgrillo@kk.kk"
            };
        }

        public void Modify(int id, Contacto contacto) {
            throw new NotImplementedException();
        }
    }
}
