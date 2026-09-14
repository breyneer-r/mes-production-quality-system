using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Contacto { get; set; }

    public virtual ICollection<Materiale> Materiales { get; set; } = new List<Materiale>();
}
