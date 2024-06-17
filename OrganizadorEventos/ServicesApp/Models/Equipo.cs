using System;
using System.Collections.Generic;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class Equipo
{
    public int EquipoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumeroIntegrantes { get; set; }

    public string Organizacion { get; set; } = null!;

    public int RepresentanteId { get; set; }

    public virtual ICollection<EquiposEvento> EquiposEventos { get; } = new List<EquiposEvento>();

    public virtual ICollection<MiembrosEquipo> MiembrosEquipos { get; } = new List<MiembrosEquipo>();

    public virtual Usuario Representante { get; set; } = null!;
}


public class EquipoRegistro{
    public string Nombre {get; set;} = null!;
    public string Organizacion {get; set;} = null!;
    public List<EquipoDatos> datos {get; set;} = null!;
    public int EventoId {get; set;}
    public int RepresentanteId {get; set;}
    public string? RepresentanteCorreo{get; set;}
}

public class EquipoDatos{
    public string? Correo {get; set;}
    public string? Nombre {get; set;}
}


public class EquipoParticipacion{
    public int EquipoId { get; set; }
    public string Nombre { get; set; } = null!;
    public int NumeroIntegrantes { get; set; }
    public string Organizacion { get; set; } = null!;
    public int RepresentanteId { get; set; }
    public bool Asistencia { get; set; }

}
