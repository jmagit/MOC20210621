using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kk.CodeTemplates {
    public partial class NombreDetalle {
        public string NombreCompleto { get => $"{Nombre} {Apellidos}"; }
    }
}
