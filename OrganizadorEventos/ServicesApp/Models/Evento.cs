using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime Inicio { get; set; }

    public DateTime Finalizacion { get; set; }

    public string LugarEvento { get; set; } = null!;

    public bool PorEquipos { get; set; }

    public int MaxPersonasPorEquipo { get; set; }

    public int OrganizadorId { get; set; }

    public virtual ICollection<EquiposEvento> EquiposEventos { get; } = new List<EquiposEvento>();

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();

    public virtual Usuario Organizador { get; set; } = null!;

    public virtual ICollection<ParticipanteEvento> ParticipanteEventos { get; } = new List<ParticipanteEvento>();
}
