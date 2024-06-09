import { Component } from '@angular/core';
import { Usuario } from '../models/interfaces/Evento.interface';

@Component({
    selector: 'app-event-participation',
    templateUrl: './event-participation.component.html',
    styleUrls: ['./event-participation.component.css']
  })
  export class EventParticipationComponent {
    Participantes: Usuario[] = []
    Quantity:number = 5
  }
  