using Microsoft.EntityFrameworkCore;
using OrganizadorEventos.ServicesApp.Models;


public class EventoService
{
    private readonly OrganizadorEventosContext _appDbContext;

    public EventoService(OrganizadorEventosContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<Evento> getAllEventosIndividuales(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
        var eventosIndividualesDb = _appDbContext.Eventos
                                    .Where(evento => evento.PorEquipos == false && evento.Finalizacion > fecha && evento.OrganizadorId != usuarioId)
                                    .Include(evento => evento.Organizador)
                                    .ToList();

        return eventosIndividualesDb;
    }



    public IEnumerable<Evento> getAllEventosGrupales(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
        var eventosgrupalesDb = _appDbContext.Eventos
                                    .Where(evento => evento.PorEquipos == true && evento.Finalizacion > fecha && evento.OrganizadorId != usuarioId)
                                    .Include(evento => evento.Organizador)
                                    .ToList();


        return eventosgrupalesDb;

    }

    public Evento getDetalleEvento(int id)
    {   
        var eventoDetalle = _appDbContext.Eventos
                            .Where(evento => evento.EventoId == id)
                            .Include(evento => evento.Organizador)
                            .First();

        
        return eventoDetalle;                   
    }



    public IEnumerable<Evento> getEventosOrganizador(int id)
    {
        DateTime fecha = DateTime.Now;
        var eventos = _appDbContext.Eventos
                        .Where(evento => evento.OrganizadorId == id && evento.Finalizacion > fecha)
                        .ToList();


        
        return eventos;
    }


}