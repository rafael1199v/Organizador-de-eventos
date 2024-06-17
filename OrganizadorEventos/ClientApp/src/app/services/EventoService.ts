import { Injectable, Inject } from "@angular/core";
import { Evento } from "../models/interfaces/Evento.interface";
import { HttpClient } from "@angular/common/http";
import { FormGroup } from "@angular/forms";
import { Usuario } from "../models/interfaces/Usuario.interface";


@Injectable()
export class EventoService{

    http: HttpClient;
    baseUrl: string;


    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.http = http;
        this.baseUrl = baseUrl;
    }

    actualizarFormatoTiempo(eventos: Evento[]): Evento[] {
      eventos.forEach(evento => {
      evento.inicio = new Date(evento.inicio);
      evento.finalizacion = new Date(evento.finalizacion);
     });
    
     return eventos;
   }



   crearEvento(eventoForm: FormGroup, porEquiposEvento: boolean, maxPersonasPorEquipoEvento: number, organizadorEvento: Usuario){
        const evento = {
            titulo: eventoForm.value.titulo,
            descripcion: eventoForm. value.descripcion,
            inicio: eventoForm.value.inicio,
            finalizacion: eventoForm.value.finalizacion,
            lugarEvento: eventoForm.value.lugarEvento,
            porEquipos: porEquiposEvento,
            maxPersonasPorEquipo: maxPersonasPorEquipoEvento,
            organizadorId: organizadorEvento.usuarioId,
            historials: [],
            organizador: organizadorEvento
        }

        console.log(evento)
        console.log(this.baseUrl + 'evento/crearEvento');

        return this.http.post<Evento>(this.baseUrl + 'evento/crearEvento', evento)

   }


   inscripcionIndividual(eventoID: number, participanteID: number){
        const participante = {
            participanteId: participanteID,
            eventoId: eventoID,
            asistencia: false
        }

        return this.http.post<any>(this.baseUrl + 'evento/registro/participante', participante);
    }


    verificarRegistro(eventoID: number, participanteID: number){
        const participante = {
            participanteId: participanteID,
            eventoId: eventoID,
            asistencia: false
        }
        console.log(participante)
        return this.http.post<any>(this.baseUrl + 'evento/verificar/registro', participante);
    }
}