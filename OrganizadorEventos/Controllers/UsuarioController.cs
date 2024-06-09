using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]

public class UsuarioController: ControllerBase
{

    private readonly OrganizadorEventosContext _appDbContext;
    public UsuarioController(OrganizadorEventosContext appDbContext){
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public IActionResult Autenticar([FromBody] UsuarioLogin user)
    {
        if(user == null) return BadRequest();

        var verificacion = new UsuarioService();
        
        if(!verificacion.AutenticarUsuario(_appDbContext, user))
        {
            return NotFound(new {Mensaje = "Usuario no encontrado"});
        }

        return Ok(verificacion.getUsuario(_appDbContext, user.Correo ,user.Contrasenha));
    }


    [HttpGet("participantes/{id}")]
    public IActionResult getPartipanteEvento(int id)
    {
        var usuarioService = new UsuarioService();

        return Ok(usuarioService.getUsuariosEvento(_appDbContext ,id)); 
    }


   
}


