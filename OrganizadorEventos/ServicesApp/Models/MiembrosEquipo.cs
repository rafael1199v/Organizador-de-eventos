using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class MiembrosEquipo
{
    public int MiembroEquipoId { get; set; }

    public int MiembroId { get; set; }

    public int EquipoId { get; set; }

    public virtual Equipo Equipo { get; set; } = null!;

    public virtual Usuario Miembro { get; set; } = null!;
}
