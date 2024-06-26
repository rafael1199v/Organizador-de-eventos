import { Injectable, Inject } from "@angular/core";
import { Evento } from "../models/interfaces/Evento.interface";
import { HttpClient } from "@angular/common/http";
import { FormGroup } from "@angular/forms";
import { Usuario, UsuarioEvento } from "../models/interfaces/Usuario.interface";
import { Equipo } from "../models/interfaces/Equipo.interface";


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
        return this.http.post<Evento>(this.baseUrl + 'evento/crearEvento', evento)

   }


   inscripcionIndividual(eventoID: number, participanteID: number, Correo: string){
        const participante = {
            participanteId: participanteID,
            eventoId: eventoID,
            asistencia: false,
            correo: Correo
        }

        return this.http.post<any>(this.baseUrl + 'evento/registro/participante', participante);
    }


    verificarRegistro(eventoID: number, participanteID: number, Correo: string){
        const participante = {
            participanteId: participanteID,
            eventoId: eventoID,
            asistencia: false,
            correo: Correo
        }
        return this.http.post<any>(this.baseUrl + 'evento/verificar/registro', participante);
    }

    guardarAsistenciaIndividual(eventoId: string, participantes: UsuarioEvento[]){
        return this.http.put<UsuarioEvento[]>(this.baseUrl + 'evento/lista/participacion/' + eventoId, participantes);
    }


    guardarAsistenciaEquipo(eventoId: string, equipos: Equipo[]){
        return this.http.put<Equipo[]>(this.baseUrl + 'evento/lista/participacion/equipo/' + eventoId, equipos);
    }


    getListaFinalParticipacionIndividual(eventoId: string){
        return this.http.get<UsuarioEvento[]>(this.baseUrl + 'usuario/lista/final/participacion/' + eventoId)
    }

}