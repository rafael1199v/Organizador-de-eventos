using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class ParticipanteEvento
{
    public int ParticipanteEventoId { get; set; }

    public int ParticipanteId { get; set; }

    public int EventoId { get; set; }

    public bool Asistencia { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Usuario Participante { get; set; } = null!;
}
