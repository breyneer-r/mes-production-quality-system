using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class Materiale
{
    public int IdMaterial { get; set; }

    public string? Nombre { get; set; }

    public int? Stock { get; set; }

    public int? IdProveedor { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual ICollection<RecetaProducto> RecetaProductos { get; set; } = new List<RecetaProducto>();
}
