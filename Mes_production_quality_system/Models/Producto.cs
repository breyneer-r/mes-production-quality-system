using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<OrdenesProduccion> OrdenesProduccions { get; set; } = new List<OrdenesProduccion>();

    public virtual ICollection<RecetaProducto> RecetaProductos { get; set; } = new List<RecetaProducto>();
}
