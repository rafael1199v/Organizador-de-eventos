import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Equipo } from "../models/interfaces/Equipo.interface";

@Injectable()
export class EquipoService{

    http: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.http = http;
        this.baseUrl = baseUrl;
    }


    registrarEquipo(teamForm: FormGroup, eventoID: number, representanteID: number, correoRepresentante: string){
        console.log(teamForm)
        const equipoInformacion = new Array<{correo: string, nombre: string}>();
        
        teamForm.value.datos.forEach((element: { correo: string; nombre: string; }) => {
            let el: {correo: string, nombre: string} = {correo: element.correo, nombre: element.nombre};
            equipoInformacion.push(el);
        });

        const equipo = {
            nombre: teamForm.value.nombreEquipo,
            organizacion: teamForm.value.nombreOrganizacion,
            datos: equipoInformacion,
            eventoId: eventoID,
            representanteId: representanteID,
            RepresentanteCorreo: correoRepresentante
        }

        return this.http.post<any>(this.baseUrl + 'equipo/registro', equipo);
    }


    getListaFinalEquiposParticipacion(eventoId: string){
        return this.http.get<Equipo[]>(this.baseUrl + 'equipo/lista/final/participacion/' + eventoId);
    }




}