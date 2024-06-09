using OrganizadorEventos.ServicesApp.Models;

public class UsuarioService
{
    public bool AutenticarUsuario(OrganizadorEventosContext _appDbContext, UsuarioLogin user)
    {

        var usuario = _appDbContext.Usuarios.FirstOrDefault(x=> x.Correo == user.Correo 
                                                        && x.Contrasenha == user.Contrasenha);

        if(usuario == null) return false;
        else return true;

    }



    public Usuario? getUsuario(OrganizadorEventosContext _appDbContext ,string? correo, string? Contrasenha)
    {
        var usuario = _appDbContext.Usuarios
                    .Where(evento => evento.Correo == correo && evento.Contrasenha == Contrasenha)
                    .FirstOrDefault();


        return usuario;
    }


    public IEnumerable<UsuarioEvento> getUsuariosEvento(OrganizadorEventosContext _appDbContext, int eventoId)
    {
        var usuarios = from usuario in _appDbContext.Usuarios
                        join participante in _appDbContext.ParticipanteEventos on usuario.UsuarioId equals participante.ParticipanteId
                        where participante.EventoId == eventoId
                        select new UsuarioEvento{
                            UsuarioId = usuario.UsuarioId,
                            Nombre = usuario.Nombre,
                            Correo = usuario.Correo,
                            Organizacion = usuario.Organizacion,
                            Asistencia = participante.Asistencia
                        };

        return usuarios.ToList();
    }
}