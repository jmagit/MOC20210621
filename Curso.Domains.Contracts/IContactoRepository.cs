using Curso.Domains.Entities;
using System.Collections.Generic;

namespace Curso.Domains.Contracts {
    public interface IContactoRepository {
        void Create(Contacto contacto);
        void Delete(int id);
        List<Contacto> GetAll();
        Contacto GetOne(int? id);
        void Modify(int id, Contacto contacto);
    }
}