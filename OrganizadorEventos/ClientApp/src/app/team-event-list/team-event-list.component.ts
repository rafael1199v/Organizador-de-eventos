import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/interfaces/Evento.interface';

@Component({
  selector: 'app-team-event-list',
  templateUrl: './team-event-list.component.html',
  styleUrls: ['./team-event-list.component.css']
})
export class TeamEventListComponent {

  eventosDisponibles: Evento[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {
    this.getInformation().subscribe(result =>{
      this.eventosDisponibles = result;
    }, error => console.log(error))
  }


  getInformation(){
    return this.http.get<any>(this.baseUrl + 'evento/' + 'grupo');
  }
}
