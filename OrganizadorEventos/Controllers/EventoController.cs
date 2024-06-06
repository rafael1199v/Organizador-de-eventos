
using Microsoft.AspNetCore.Mvc;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]

public class EventoController : ControllerBase
{
    private readonly OrganizadorEventosContext _appDbContext;


    public EventoController(OrganizadorEventosContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    [HttpGet]

    public IEnumerable<Evento> getEventosIndividuales()
    {

        var eventos = new EventoService(_appDbContext);
        IEnumerable<Evento> a = eventos.getAllEventosIndividuales();
        return a;

    }

    
}