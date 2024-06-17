
using OrganizadorEventos.ServicesApp.Models;

public class EquipoService{


    public bool verificarExistenciaEvento(OrganizadorEventosContext _appDbContext, string? nombreEquipo, int eventoId)
    {
        var Equipo = (from equipo in _appDbContext.Equipos
                        join eventoEquipo in _appDbContext.EquiposEventos on equipo.EquipoId equals eventoEquipo.EquipoId
                        where eventoEquipo.EventoId == eventoId && equipo.Nombre == nombreEquipo
                        select equipo).FirstOrDefault();


        if(Equipo == null) return false;
        else return false;
    }


    public void registrarEquipo(OrganizadorEventosContext _appDbContext, EquipoRegistro equipoRegistro, int eventoID)
    {

        List<string?> correos = this.getCorreos(equipoRegistro.datos);

        var identificadores = (from usuario in _appDbContext.Usuarios
                                where correos.Contains(usuario.Correo)
                                select usuario.UsuarioId).ToList();

        System.Console.WriteLine("La cantidad de identificadores = " + identificadores.Count);

        if(identificadores.Count != equipoRegistro.datos.Count){
            System.Console.WriteLine("Algun usuario no esta registrado");
            return;
        }

        var equipo = new Equipo{
            Nombre = equipoRegistro.Nombre,
            NumeroIntegrantes = equipoRegistro.datos.Count,
            Organizacion = equipoRegistro.Organizacion,
            RepresentanteId = equipoRegistro.RepresentanteId,
        };

        _appDbContext.Equipos.Add(equipo);
        _appDbContext.SaveChanges();
       

        int equipoId = equipo.EquipoId;

        var equipoEvento = new EquiposEvento{
            EquipoId = equipoId,
            EventoId = eventoID,
            Asistencia = false
        };

        _appDbContext.EquiposEventos.Add(equipoEvento);
   

        List<MiembrosEquipo> miembros = new List<MiembrosEquipo>();
        for(int i = 0; i < identificadores.Count; i++){
            var temp = new MiembrosEquipo{
                MiembroId = identificadores[i],
                EquipoId = equipoId
            };

            miembros.Add(temp);
        }

        _appDbContext.MiembrosEquipos.AddRange(miembros);
        _appDbContext.SaveChanges();


        foreach(var a in miembros){
            System.Console.WriteLine(a.MiembroId + " " + a.EquipoId);
        }
       
    }


   public List<string?> getCorreos(List<EquipoDatos> datos)
   {
        List<string?> correos = new List<string?>();

        foreach(var dato in datos)
        {
            correos.Add(dato.Correo);
        }

        return correos;
   }


   public List<EquipoParticipacion> getEquiposParticipantes(OrganizadorEventosContext _appDbContext, int eventoId)
   {
        var equipos = (from equipo in _appDbContext.Equipos
                        join equipoEvento in _appDbContext.EquiposEventos on equipo.EquipoId equals equipoEvento.EquipoId
                        where equipoEvento.EventoId == eventoId
                        orderby equipo.Nombre
                        select new EquipoParticipacion{
                            EquipoId = equipo.EquipoId,
                            Nombre = equipo.Nombre,
                            NumeroIntegrantes = equipo.NumeroIntegrantes,
                            Organizacion = equipo.Organizacion,
                            RepresentanteId = equipo.RepresentanteId,
                            Asistencia = equipoEvento.Asistencia
                        }).ToList();

        return equipos;
   }

     
}