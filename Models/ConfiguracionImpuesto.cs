using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class ConfiguracionImpuesto
    {
        public int IdConfiguracion { get; set; }
        public int? IdImpuesto { get; set; }
        public int? IdFactura { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }
        public virtual Impuesto? IdImpuestoNavigation { get; set; }
    }
}
