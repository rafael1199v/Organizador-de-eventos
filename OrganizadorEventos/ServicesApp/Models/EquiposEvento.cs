using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class EquiposEvento
{
    public int EquipoEventoId { get; set; }

    public int EquipoId { get; set; }

    public int EventoId { get; set; }

    public bool Asistencia { get; set; }

    public virtual Equipo Equipo { get; set; } = null!;

    public virtual Evento Evento { get; set; } = null!;
}
