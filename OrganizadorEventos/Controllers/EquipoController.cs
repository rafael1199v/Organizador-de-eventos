

using Microsoft.AspNetCore.Mvc;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]


public class EquipoController : ControllerBase
{
    private readonly OrganizadorEventosContext _appDbContext;

    public EquipoController(OrganizadorEventosContext appDbContext)
    {
        _appDbContext = appDbContext;
    }



    [HttpPost("registro")]
    public IActionResult registrarEquipo([FromBody] EquipoRegistro equipoDatos)
    {
        
        var equipoService = new EquipoService();


        foreach(var a in equipoDatos.datos)
        {
            System.Console.WriteLine(a.Nombre + " " + a.Correo);
        }


        if(equipoService.verificarExistenciaEvento(_appDbContext, equipoDatos.Nombre, equipoDatos.EventoId)){
            return BadRequest(new {Message = "El evento ya existe"});   
        }

        System.Console.WriteLine(equipoDatos.Nombre);
        System.Console.WriteLine(equipoDatos.Organizacion);
        System.Console.WriteLine(equipoDatos.RepresentanteId);
        System.Console.WriteLine(equipoDatos.EventoId);


        return Ok();
    }

}
