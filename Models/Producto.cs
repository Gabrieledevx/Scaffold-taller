using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
    }
}
