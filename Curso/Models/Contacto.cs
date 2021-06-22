using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Models {
    public class Contacto {
        public int Id { get; set; }
        public string Tratamiento { get; set; }
        public string Nombre  { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public bool Activo { get; set; } = true;

        public void Desactivar() {
            Activo = false;
        }
        public bool EsValido() {
            return true;
        }
        public bool EsInvalido() {
            return !EsValido();
        }

    }
}
