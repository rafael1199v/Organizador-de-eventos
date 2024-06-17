import { Component, Inject } from '@angular/core';
import { Usuario, UsuarioEvento } from '../models/interfaces/Usuario.interface';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { EventoService } from '../services/EventoService';




@Component({
    selector: 'app-event-participation',
    templateUrl: './event-participation.component.html',
    styleUrls: ['./event-participation.component.css']
  })
  export class EventParticipationComponent {
    Participantes: UsuarioEvento[] = []
   
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, private eventoService: EventoService, private router: Router){
      this.getParticipants().subscribe( resultado => {
        this.Participantes = resultado;
        console.log(this.Participantes);
      }, error => console.log(error));
    }

    getParticipants(){
      return this.http.get<UsuarioEvento[]>(this.baseUrl + 'usuario/participantes/' + this.activatedRoute.snapshot.paramMap.get('id'))
    }


    verificarAsistencia(participante: UsuarioEvento){
      participante.asistencia = !participante.asistencia;
    }

    guardarAsistencia(){
      this.eventoService.guardarAsistenciaIndividual((this.activatedRoute.snapshot.paramMap.get('id') || '-1'), this.Participantes).subscribe(result => {alert('Cambios guardados')});
      this.router.navigate(['/my-events'])
    }
  }
  