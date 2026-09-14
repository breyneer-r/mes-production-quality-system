using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class OrdenesProduccion
{
    public int IdOrden { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public string? Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual ICollection<InspeccionesCalidad> InspeccionesCalidads { get; set; } = new List<InspeccionesCalidad>();
}
