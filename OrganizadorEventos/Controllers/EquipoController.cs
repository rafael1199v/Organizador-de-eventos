

using Microsoft.AspNetCore.Mvc;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]


public class EquipoController : ControllerBase
{
    private readonly OrganizadorEventosContext _appDbContext;
    private readonly IEmailService _emailService;
    public EquipoController(OrganizadorEventosContext appDbContext, IEmailService emailService)
    {
        _appDbContext = appDbContext;
        _emailService = emailService;
    }



    [HttpPost("registro")]
    public IActionResult registrarEquipo([FromBody] EquipoRegistro equipoDatos)
    {
        
        var equipoService = new EquipoService();

        if(equipoService.verificarExistenciaEquipoEvento(_appDbContext, equipoDatos.Nombre, equipoDatos.EventoId))
        {
            return BadRequest(new {Mensage = "Un equipo con este nombre ya existe"});   
        }
        else if(!equipoService.verificarIntegrantesRegistrados(_appDbContext, equipoDatos))
        {
            return NotFound(new {Mensaje = "Alguno de los integrantes no se encuentra registrado"});
        }

        equipoService.registrarEquipo(_appDbContext, equipoDatos, equipoDatos.EventoId, _emailService);
        
        return Ok();
    }


    [HttpGet("participacion/{id}")]
    public IActionResult getEquiposParticipantes(int id)
    {
        var equipoService = new EquipoService();
        return Ok(equipoService.getEquiposParticipantes(_appDbContext, id));
    }


    [HttpGet("lista/final/participacion/{eventoId}")]
    public IActionResult getListaFinalEquiposParticipacion(int eventoId)
    {
        var equipoService = new EquipoService();
        return Ok(equipoService.getEquiposParticipantesHistorial(_appDbContext, eventoId));
    }


}
