using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;
using OrganizadorEventos.ServicesApp.Models;


public class EventoService
{
    private readonly OrganizadorEventosContext _appDbContext;

    public EventoService(OrganizadorEventosContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<Evento> getAllEventosIndividuales()
    {
        var eventosIndividualesDb = _appDbContext.Eventos
                                    .Include(evento => evento.Historials)
                                    .Include(evento => evento.Organizador)
                                    .ToList();

        return eventosIndividualesDb;
    }


}