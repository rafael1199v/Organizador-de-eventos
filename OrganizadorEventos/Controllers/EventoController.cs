
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


    [HttpGet("individual/{usuarioId}")]

    public IActionResult getEventosIndividuales(int usuarioId)
    {

        var eventos = new EventoService(_appDbContext);
        return Ok(eventos.getAllEventosIndividuales(usuarioId));

    }


    [HttpGet("grupo/{usuarioId}")]
    public IActionResult getEventosGrupales(int usuarioId)
    {
        var eventos = new EventoService(_appDbContext);
        return Ok(eventos.getAllEventosGrupales(usuarioId));
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


    [HttpGet("organizador/{id}")]
    public IActionResult getHistorialEventosOrganizador(int id)
    {
        var eventoService = new EventoService(_appDbContext);
        return Ok(eventoService.getHistorialEventoOrganizador(id));
    }


    [HttpGet("participante/{id}")]
    public IActionResult getHistorialEventoParticipante(int id)
    {
        var eventoService = new EventoService(_appDbContext);
        return Ok(eventoService.getHistorialEventoPartipante(id));
    }

    [HttpPost("crearEvento")]
    public IActionResult crearEventos([FromBody] Evento evento)
    {

        var even = new Evento{
            Titulo = evento.Titulo,
            Descripcion = evento.Descripcion,
            Inicio = evento.Inicio,
            Finalizacion = evento.Finalizacion,
            LugarEvento = evento.LugarEvento,
            PorEquipos = evento.PorEquipos,
            MaxPersonasPorEquipo = evento.MaxPersonasPorEquipo,
            OrganizadorId = evento.OrganizadorId,
        };
        
       _appDbContext.Eventos.Add(even);
       _appDbContext.SaveChanges();

        return Ok();
    }
    
}