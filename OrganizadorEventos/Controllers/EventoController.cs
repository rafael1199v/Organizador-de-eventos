
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

    public IActionResult getEventosIndividuales()
    {

        var eventos = new EventoService(_appDbContext);
        return Ok(eventos.getAllEventosIndividuales());

    }


    [HttpGet("grupo")]
    public IActionResult getEventosGrupales()
    {
        var eventos = new EventoService(_appDbContext);
        return Ok(eventos.getAllEventosGrupales());
    }


    [HttpGet("detalle/{id}")]

    public IActionResult getEvento(int id)
    {
        var eventosService = new EventoService(_appDbContext);
        return Ok(eventosService.getDetalleEvento(id));
    }


    [HttpGet("{id}")]
    public IActionResult getEventosOrganizador(int id)
    {
        var eventosService = new EventoService(_appDbContext);
        return Ok(eventosService.getEventosOrganizador(id));
    }
    
}