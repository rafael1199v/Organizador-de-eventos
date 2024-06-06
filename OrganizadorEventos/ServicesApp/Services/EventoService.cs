using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;
using OrganizadorEventos.ServicesApp.Models;


public class EventoService
{

    static int i = 1;


    private readonly OrganizadorEventosContext _appDbContext;

    public EventoService(OrganizadorEventosContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public static void increment(){
        i++;
    }



    public IEnumerable<Evento> getAllEventosIndividuales()
    {
        

        System.Console.WriteLine(i);
        
        increment();

        var eventosIndividualesDb = _appDbContext.Eventos
                                    .Include(evento => evento.Historials)
                                    .Include(evento => evento.Organizador)
                                    .ToList();



        List<Evento> eventosIndividuales = new List<Evento>();


        foreach(var evento in eventosIndividualesDb)
        {
            eventosIndividuales.Add(new Evento{
                EventoId = evento.EventoId,
                Descripcion = evento.Descripcion,
                Inicio = evento.Inicio,
                Finalizacion = evento.Finalizacion,
                LugarEvento = evento.LugarEvento,
                PorEquipos = evento.PorEquipos,
                OrganizadorId = evento.OrganizadorId,
                Organizador = evento.Organizador,
            });
        }
        
        return eventosIndividuales;
    }


}