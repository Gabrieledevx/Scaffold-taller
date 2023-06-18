using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int? IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }
    }
}
