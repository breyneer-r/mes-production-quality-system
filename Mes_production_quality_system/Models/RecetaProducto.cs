using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class RecetaProducto
{
    public int IdReceta { get; set; }

    public int? IdProducto { get; set; }

    public int? IdMaterial { get; set; }

    public decimal? CantidadRequerida { get; set; }

    public virtual Materiale? IdMaterialNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
