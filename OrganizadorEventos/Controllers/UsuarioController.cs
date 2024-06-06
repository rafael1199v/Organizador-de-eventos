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
    public async Task<IActionResult> Autenticar([FromBody] UsuarioLogin user)
    {
        if(user == null) return BadRequest();

        var User = await _appDbContext.Usuarios.FirstOrDefaultAsync(x=> x.Correo == user.Correo && x.Contrasenha == user.Contrasenha);

        if(User == null) return NotFound(new {Mensaje = "Usuario no encontrado"});
        
        return Ok(new
        {
            Mensaje = "Autenticacion correcta"
        });

        
    }
}


