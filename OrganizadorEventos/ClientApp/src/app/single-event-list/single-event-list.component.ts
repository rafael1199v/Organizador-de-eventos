import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { Inject } from '@angular/core';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-single-event-list',
  templateUrl: './single-event-list.component.html',
  styleUrls: ['./single-event-list.component.css']
})
export class SingleEventListComponent {

  eventosDisponibles: Evento[] = [];
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
    this.getInformation().subscribe(result => {
      this.eventosDisponibles = result;
    }, error => console.log(error));
  }


  getInformation(){
    return this.http.get<any>(this.baseUrl + 'evento');
  }
}

interface Evento{
  eventoId: number
  descripcion: string,
  inicio: Date,
  finalizacion: Date,
  lugarEvento: string,
  organizadorId: number,
  historials: any,
  organizador: any
}
