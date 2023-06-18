using System;
using System.Collections.Generic;

namespace Scaffold_taller.Models
{
    public partial class Impuesto
    {
        public Impuesto()
        {
            ConfiguracionImpuestos = new HashSet<ConfiguracionImpuesto>();
        }

        public int IdImpuesto { get; set; }
        public string? Nombre { get; set; }
        public decimal? Tasa { get; set; }

        public virtual ICollection<ConfiguracionImpuesto> ConfiguracionImpuestos { get; set; }
    }
}
