
using OrganizadorEventos.ServicesApp.Models;

public class EquipoService{


    public bool verificarExistenciaEvento(OrganizadorEventosContext _appDbContext, string? nombreEquipo, int eventoId)
    {
        var Equipo = (from equipo in _appDbContext.Equipos
                        join eventoEquipo in _appDbContext.EquiposEventos on equipo.EquipoId equals eventoEquipo.EquipoId
                        where eventoEquipo.EventoId == eventoId && equipo.Nombre == nombreEquipo
                        select equipo).FirstOrDefault();


        if(Equipo == null) return false;
        else return false;
    }

     
}