using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kk.CodeTemplates {
    class NombreDetalleAnotada {
        [StringLength(10)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

    }
    [MetadataType(typeof(NombreDetalleAnotada))]
    public partial class NombreDetalle {
        public string NombreCompleto { get => $"{Nombre} {Apellidos}"; }
    }
}
