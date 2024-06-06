
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


    [HttpGet("individual")]

    public IEnumerable<Evento> getEventosIndividuales()
    {

        var eventos = new EventoService(_appDbContext);
        return eventos.getAllEventosIndividuales();

    }


    [HttpGet("grupo")]
    public IEnumerable<Evento> getEventosGrupales()
    {
        var eventos = new EventoService(_appDbContext);
        return eventos.getAllEventosGrupales();
    }
    
}