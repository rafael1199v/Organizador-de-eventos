import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {UsuarioEvento } from "src/app/models/interfaces/Usuario.interface";
import { EventoService } from "src/app/services/EventoService";
import { ActivatedRoute } from "@angular/router";



@Component({
    selector: 'app-final-participation-list',
    templateUrl: './final-participation-list.html',
    styles : ['']
})
export class FinalParticipationListComponent{
    
    participantes: UsuarioEvento[] = []
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private eventoService: EventoService, private activatedRouter: ActivatedRoute){
        this.getListaFinalParticipationIndividual();
    }
    

    getListaFinalParticipationIndividual(){
        let eventoId: string = (this.activatedRouter.snapshot.paramMap.get('eventId') || '-1');
        this.eventoService.getListaFinalParticipacionIndividual(eventoId).subscribe(result => {
            this.participantes = result;
            console.log(result);
        }, error => console.log(error))
    }

}