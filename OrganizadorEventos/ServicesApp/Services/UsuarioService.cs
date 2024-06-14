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



    public List<UsuarioEvento> OrdenarUsuarios(List<UsuarioEvento> usuarios)
    {
        for(int i = 0; i < usuarios.Count; i++)
        {
            for(int j = 0; j < usuarios.Count - 1; j++)
            {
                if(usuarios[j].Nombre[0] > usuarios[j + 1].Nombre[0])
                {
                    UsuarioEvento temp = usuarios[j];
                    usuarios[j] = usuarios[j + 1];
                    usuarios[j + 1] = temp;
                }
            }
        }

        return usuarios;
    }


    public List<UsuarioEvento> getUsuariosEvento(OrganizadorEventosContext _appDbContext, int eventoId)
    {
        var usuarios = from usuario in _appDbContext.Usuarios
                        join participante in _appDbContext.ParticipanteEventos on usuario.UsuarioId equals participante.ParticipanteId
                        where participante.EventoId == eventoId
                        orderby usuario.Nombre
                        select new UsuarioEvento{
                            UsuarioId = usuario.UsuarioId,
                            Nombre = usuario.Nombre,
                            Correo = usuario.Correo,
                            Organizacion = usuario.Organizacion,
                            Asistencia = participante.Asistencia
                        };


      

        return usuarios.ToList();
    }



    public bool emailExistencia(OrganizadorEventosContext _appDbContext,string correo)
    {
        var Usuario = (from usuario in _appDbContext.Usuarios
                        where usuario.Correo == correo
                        select usuario).FirstOrDefault();


        if(Usuario == null)
        {
            return false;
        }


        return true;
    }
}