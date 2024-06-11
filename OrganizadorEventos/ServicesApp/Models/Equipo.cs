using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class Equipo
{
    public int EquipoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumeroIntegrantes { get; set; }

    public int RepresentanteId { get; set; }

    public virtual ICollection<EquiposEvento> EquiposEventos { get; } = new List<EquiposEvento>();

    public virtual ICollection<MiembrosEquipo> MiembrosEquipos { get; } = new List<MiembrosEquipo>();

    public virtual Usuario Representante { get; set; } = null!;
}
