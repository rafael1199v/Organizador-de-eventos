using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Contrasenha { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Organizacion { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public virtual ICollection<Equipo> Equipos { get; } = new List<Equipo>();

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();

    public virtual ICollection<MiembrosEquipo> MiembrosEquipos { get; } = new List<MiembrosEquipo>();

    public virtual ICollection<ParticipanteEvento> ParticipanteEventos { get; } = new List<ParticipanteEvento>();
}


public class UsuarioLogin{
    public string? Correo {get; set;}
    public string? Contrasenha {get; set;}
}
