using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using OrganizadorEventos.ServicesApp.Models;

[ApiController]
[Route("[controller]")]

public class UsuarioController: ControllerBase
{

    public UsuarioController(){}

    [HttpGet]

    public IEnumerable<Usuario> GetAllUsuarios()
    {
        var servicio = new UsuarioService();
        return servicio.GetUsuarios();

    }

}


