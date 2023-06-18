using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class Factura
    {
        public Factura()
        {
            ConfiguracionImpuestos = new HashSet<ConfiguracionImpuesto>();
            DetallesFacturas = new HashSet<DetallesFactura>();
            Pagos = new HashSet<Pago>();
        }

        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<ConfiguracionImpuesto> ConfiguracionImpuestos { get; set; }
        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
