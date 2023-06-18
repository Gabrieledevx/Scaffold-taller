using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasena { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
