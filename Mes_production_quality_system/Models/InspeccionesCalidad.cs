using System;
using System.Collections.Generic;

namespace Mes_production_quality_system.Models;

public partial class InspeccionesCalidad
{
    public int IdInspeccion { get; set; }

    public int? IdOrden { get; set; }

    public string? Resultado { get; set; }

    public int? Defectuosos { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual OrdenesProduccion? IdOrdenNavigation { get; set; }
}
