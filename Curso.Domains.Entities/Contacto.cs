using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Curso.Domains.Entities {
    public class Contacto : IValidatableObject {
        [Required]
        public int Id { get; set; }
        [StringLength(10)]
        public string Tratamiento { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre  { get; set; }
        [StringLength(100)]
        public string Apellidos { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FNacimiento { get; set; }

        public bool Activo { get; set; } = true;

        public void Desactivar() {
            Activo = false;
        }
        IEnumerable<ValidationResult> Errores { 
            get {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(this, null, null);
                Validator.TryValidateObject(this,
                          context,
                          validationResults,
                          true);
                return validationResults;
            } 
        }

        public bool EsValido() {
            return Errores.Count() == 0;
        }
        public bool EsInvalido() {
            return !EsValido();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (FNacimiento.Date.CompareTo(DateTime.Today) == 1)
                yield return new ValidationResult("Todavía no ha nacido", new[] { nameof(FNacimiento) });

        }
    }
}
