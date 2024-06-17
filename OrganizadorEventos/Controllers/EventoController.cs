
using Microsoft.AspNetCore.Mvc;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]

public class EventoController : ControllerBase
{
    private readonly EventoService _eventoService;


    public EventoController(EventoService eventoService)
    {
        _eventoService = eventoService;
    }


    [HttpGet("individual/{usuarioId}")]

    public IActionResult getEventosIndividuales(int usuarioId)
    {
        return Ok(this._eventoService.getAllEventosIndividuales(usuarioId));

    }


    [HttpGet("grupo/{usuarioId}")]
    public IActionResult getEventosGrupales(int usuarioId)
    {
        return Ok(this._eventoService.getAllEventosGrupales(usuarioId));
    }


    [HttpGet("detalle/{id}")]

    public IActionResult getEvento(int id)
    {
        return Ok(this._eventoService.getDetalleEvento(id));
    }


    [HttpGet("{id}")]
    public IActionResult getEventosOrganizador(int id)
    {

        return Ok(this._eventoService.getEventosOrganizador(id));
    }


    [HttpGet("organizador/{id}")]
    public IActionResult getHistorialEventosOrganizador(int id)
    {
        return Ok(this._eventoService.getHistorialEventoOrganizador(id));
    }


    [HttpGet("participante/{id}")]
    public IActionResult getHistorialEventoParticipante(int id)
    {
       
        var eventos1 = this._eventoService.getHistorialEventoPartipante(id);
        var eventos2 = this._eventoService.getHistorialEventoPartipanteEquipo(id);
        var eventos3 = this._eventoService.getHistorialEventoRepresentante(id);

        var resultado = eventos1.Concat(eventos2.Concat(eventos3));
        return Ok(resultado);
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
        
        this._eventoService.crearEvento(evento);
        return Ok();
    }
    
}