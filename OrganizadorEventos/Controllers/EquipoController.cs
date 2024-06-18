

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


        foreach(var a in equipoDatos.datos)
        {
            System.Console.WriteLine(a.Nombre + " " + a.Correo);
        }

        System.Console.WriteLine("Representante: " + equipoDatos.RepresentanteCorreo);

        if(equipoService.verificarExistenciaEvento(_appDbContext, equipoDatos.Nombre, equipoDatos.EventoId)){
            return BadRequest(new {Message = "El evento ya existe"});   
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


}
