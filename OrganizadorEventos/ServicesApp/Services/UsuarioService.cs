using OrganizadorEventos.ServicesApp.Models;

public class UsuarioService
{
    public bool AutenticarUsuario(OrganizadorEventosContext _appDbContext, UsuarioLogin user)
    {

        var User = _appDbContext.Usuarios.FirstOrDefault(x=> x.Correo == user.Correo 
                                                        && x.Contrasenha == user.Contrasenha);

        if(User == null) return false;
        else return true;

    }



    public Usuario? getUsuario(OrganizadorEventosContext _appDbContext ,string? correo, string? Contrasenha)
    {
        var user = _appDbContext.Usuarios
                    .Where(evento => evento.Correo == correo && evento.Contrasenha == Contrasenha)
                    .FirstOrDefault();


        return user;
    }
}