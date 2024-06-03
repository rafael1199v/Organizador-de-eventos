using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class Historial
{
    public int HistorialId { get; set; }

    public int UsuarioId { get; set; }

    public int EventoId { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
