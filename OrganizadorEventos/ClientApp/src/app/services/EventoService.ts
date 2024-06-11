import { Evento } from "../models/interfaces/Evento.interface";



export class EventoService{

   actualizarFormatoTiempo(eventos: Evento[]): Evento[] {
    eventos.forEach(evento => {
        evento.inicio = new Date(evento.inicio);
        evento.finalizacion = new Date(evento.finalizacion);
    });
    
    return eventos;
   }
}