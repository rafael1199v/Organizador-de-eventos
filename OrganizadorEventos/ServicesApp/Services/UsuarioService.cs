


using OrganizadorEventos.ServicesApp.Models;

public class UsuarioService
{

    public List<Usuario> GetUsuarios(){
        var date = new DateTime(2024, 06, 03);
        var usuarios = new List<Usuario>(){
            new Usuario{UsuarioId = 1, Nombre = "Rafael", Direccion = "Calle Prueba", FechaNacimiento = date, Correo = "rafael1199v@gmail.com", Telefono = "76848909", Organizacion = "Ucb", Cargo = "Estudiante"}
        };
        
        return usuarios;

    }




}