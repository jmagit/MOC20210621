using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Models {
    public class ContactoService {
        public Contacto Get(int id) {
            return new Contacto() {
                Id = id, Nombre = "Pepito",
                Apellidos = "Grillo", Correo = "pgrillo@kk.kk"
            };
        }
    }
}
