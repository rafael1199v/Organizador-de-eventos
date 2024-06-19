using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]

public class UsuarioController: ControllerBase
{

    private readonly OrganizadorEventosContext _appDbContext;
    private readonly IEmailService _emailService;
    public UsuarioController(OrganizadorEventosContext appDbContext, IEmailService emailService){
        _appDbContext = appDbContext;
        _emailService = emailService;
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

    
    [HttpPost("registro")]
    public IActionResult validarUsuario([FromBody] Usuario usuario)
    {
        var usuarioService = new UsuarioService();

        if(usuarioService.emailExistencia(_appDbContext, usuario.Correo))
        {
            return BadRequest(new {Mensaje = "El correo ya esta en uso"});
        }

        _appDbContext.Usuarios.Add(usuario);
        _appDbContext.SaveChanges();

        return Ok(new {Mensaje = "Registrado Exitosamente"});
    }


   
}


