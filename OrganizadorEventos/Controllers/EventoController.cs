
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
        
        this._eventoService.crearEvento(even);
        return Ok();
    }


    [HttpPost("registro/participante")]
    public IActionResult registroPartipante([FromBody] UsuarioRegistroEvento usuario)
    {
        this._eventoService.registrarParticipante(usuario);
        return Ok();
    }

    [HttpPost("verificar/registro")]
    public IActionResult verificarRegistroParticipante([FromBody] UsuarioRegistroEvento usuario)
    {
        if(this._eventoService.ParticipanteRegistrado(usuario.ParticipanteId, usuario.EventoId)){
            return Ok(true);
        }
        else{
            return Ok(false);
        }
    }

    [HttpPut("lista/participacion/{eventoId}")]
    public IActionResult updateListaParticipacion(int eventoId, [FromBody] List<UsuarioEvento> usuarios)
    {
        var usuarioService = new UsuarioService();
        var context = new OrganizadorEventosContext();
        List<ParticipanteEvento> participantes;

      
        participantes = (from participanteEvento in context.ParticipanteEventos
                        join usuario in context.Usuarios on participanteEvento.ParticipanteId equals usuario.UsuarioId
                        where participanteEvento.EventoId == eventoId
                        orderby usuario.Nombre
                        select participanteEvento).ToList();
        

       
        for(int i = 0; i < usuarios.Count; i++)
        {
            participantes[i].Asistencia = usuarios[i].Asistencia;
        }

        context.SaveChanges();

        return Ok();
    }

    [HttpPut("lista/participacion/equipo/{eventoId}")]
    public IActionResult updateListaParticipacionEquipo(int eventoId, [FromBody] List<EquipoParticipacion> equipos)
    {
        var usuarioService = new UsuarioService();
        var context = new OrganizadorEventosContext();
        List<EquiposEvento> equiposParticipantes;

      
        equiposParticipantes = (from equipoEvento in context.EquiposEventos
                                join equipo in context.Equipos on equipoEvento.EquipoId equals equipo.EquipoId
                                where equipoEvento.EventoId == eventoId
                                orderby equipo.Nombre
                                select equipoEvento).ToList();
        

       
        for(int i = 0; i < equiposParticipantes.Count; i++)
        {
            equiposParticipantes[i].Asistencia = equipos[i].Asistencia;
        }

        context.SaveChanges();

        return Ok();
    }
    
}