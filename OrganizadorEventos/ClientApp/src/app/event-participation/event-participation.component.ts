import { Component, Inject } from '@angular/core';
import { UsuarioEvento } from '../models/interfaces/Evento.interface';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';




@Component({
    selector: 'app-event-participation',
    templateUrl: './event-participation.component.html',
    styleUrls: ['./event-participation.component.css']
  })
  export class EventParticipationComponent {
    Participantes: UsuarioEvento[] = []
    Quantity:number = 5


    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute){
      this.getParticipants().subscribe( resultado => {
        this.Participantes = resultado;
        console.log(this.Participantes);
      }, error => console.log(error));
    }




    getParticipants(){
      let porEquipos: Boolean = Boolean(this.activatedRoute.snapshot.paramMap.get('teamOrsingle'));

      if(!porEquipos){
        return this.http.get<UsuarioEvento[]>(this.baseUrl + 'usuario/participantes/' + this.activatedRoute.snapshot.paramMap.get('id'))
      }
      else{
        //TODO: Tengo que cambiar la ruta del endpoint para ver los eventos por equipo
        return this.http.get<UsuarioEvento[]>(this.baseUrl + 'usuario/participantes/' + this.activatedRoute.snapshot.paramMap.get('id'))
      }

    }




  }
  