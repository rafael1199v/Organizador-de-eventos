using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OrganizadorEventos.ServicesApp.Models;


public class EventoService
{
    private readonly OrganizadorEventosContext _appDbContext;
    private readonly IEmailService _emailService;

    public EventoService(OrganizadorEventosContext appDbContext, IEmailService emailService)
    {
        _appDbContext = appDbContext;
        _emailService = emailService;
    }

    public IEnumerable<Evento> getAllEventosIndividuales(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
        var eventosIndividualesDb = _appDbContext.Eventos
                                    .Where(evento => evento.PorEquipos == false && evento.Finalizacion > fecha && evento.OrganizadorId != usuarioId)
                                    .Include(evento => evento.Organizador)
                                    .ToList();

        return eventosIndividualesDb;
    }



    public IEnumerable<Evento> getAllEventosGrupales(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
        var eventosgrupalesDb = _appDbContext.Eventos
                                    .Where(evento => evento.PorEquipos == true && evento.Finalizacion > fecha && evento.OrganizadorId != usuarioId)
                                    .Include(evento => evento.Organizador)
                                    .ToList();


        return eventosgrupalesDb;

    }

    public Evento getDetalleEvento(int id)
    {   
        var eventoDetalle = _appDbContext.Eventos
                            .Where(evento => evento.EventoId == id)
                            .Include(evento => evento.Organizador)
                            .First();

        
        return eventoDetalle;                   
    }



    public IEnumerable<Evento> getEventosOrganizador(int id)
    {
        DateTime fecha = DateTime.Now;
        var eventos = _appDbContext.Eventos
                        .Where(evento => evento.OrganizadorId == id && evento.Finalizacion > fecha)
                        .ToList();


        
        return eventos;
    }


    public IEnumerable<Evento> getHistorialEventoPartipante(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
       
        var eventos = (from evento in _appDbContext.Eventos
                        join participanteEvento in _appDbContext.ParticipanteEventos on evento.EventoId equals participanteEvento.EventoId
                        where participanteEvento.ParticipanteId == usuarioId && evento.Finalizacion <= fecha && participanteEvento.Asistencia == true
                        select evento).ToList();
        
        
        
        return eventos;
    }

    public IEnumerable<Evento> getHistorialEventoPartipanteEquipo(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
       
        var eventos = (from evento in _appDbContext.Eventos
                        join equipoEvento in _appDbContext.EquiposEventos on evento.EventoId equals equipoEvento.EventoId
                        join miembroEquipo in _appDbContext.MiembrosEquipos on equipoEvento.EquipoId equals miembroEquipo.EquipoId
                        where miembroEquipo.MiembroId == usuarioId && evento.Finalizacion <= fecha && equipoEvento.Asistencia == true
                        select evento).ToList();
      
        
        
        return eventos;
    }


    public IEnumerable<Evento> getHistorialEventoRepresentante(int usuarioId)
    {
        DateTime fecha = DateTime.Now;
        //Revisar
      
        var eventos = (from evento in _appDbContext.Eventos
                            join equipoEvento in _appDbContext.EquiposEventos on evento.EventoId equals equipoEvento.EventoId
                            join equipo in _appDbContext.Equipos on equipoEvento.EquipoId equals equipo.EquipoId
                            where !(from miembroEquipo in _appDbContext.MiembrosEquipos
                                    where miembroEquipo.EquipoId == equipo.EquipoId
                                    select miembroEquipo.MiembroId).Contains(equipo.RepresentanteId) && evento.Finalizacion <= fecha && equipoEvento.Asistencia == true && equipo.RepresentanteId == usuarioId
                                    select evento).Distinct().ToList();
       
        
        return eventos;
    }



    public IEnumerable<Evento> getHistorialEventoOrganizador(int usuarioId)
    {
        DateTime fecha = DateTime.Now;

        var eventos = from evento in _appDbContext.Eventos
                        where evento.OrganizadorId == usuarioId && evento.Finalizacion <= fecha
                        select evento;


        return eventos.ToList();
    }


    public void crearEvento(Evento evento){
        _appDbContext.Eventos.Add(evento);
        _appDbContext.SaveChanges();
    }

    public void registrarParticipante(UsuarioRegistroEvento usuario){

        var Usuario = new ParticipanteEvento{
            ParticipanteId = usuario.ParticipanteId,
            EventoId = usuario.EventoId,
            Asistencia = usuario.Asistencia,
        };

        //TODO: Mandar Comprobante por gmail


        var nombreEvento = (from evento in _appDbContext.Eventos
                                where evento.EventoId == usuario.EventoId
                                select evento.Titulo).FirstOrDefault();
    
        _appDbContext.ParticipanteEventos.Add(Usuario);
        _appDbContext.SaveChanges();

        var request = new EmailDTO{Destinatario = usuario.Correo, Asunto = "Registro a evento: " + nombreEvento, Contenido = "<p>Comprobante de registro a un evento</p>"};
        _emailService.SendEmail(request);

    }


    public bool ParticipanteRegistrado(int usuarioId, int eventoId)
    {
        var participante = (from participantes in _appDbContext.ParticipanteEventos
                        where participantes.ParticipanteId == usuarioId && participantes.EventoId == eventoId
                        select participantes).FirstOrDefault();

        if(participante == null) return false;
        else return true;

    }


}