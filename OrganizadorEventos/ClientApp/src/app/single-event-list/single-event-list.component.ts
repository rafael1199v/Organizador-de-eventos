import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { Inject } from '@angular/core';
import { Evento } from '../models/interfaces/Evento.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-single-event-list',
  templateUrl: './single-event-list.component.html',
  styleUrls: ['./single-event-list.component.css']
})
export class SingleEventListComponent {

  eventosDisponibles: Evento[] = [];
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router){
    this.getInformation().subscribe(result => {
      this.eventosDisponibles = result;
    }, error => console.log(error));
  }


  getInformation(){
    return this.http.get<Evento[]>(this.baseUrl + 'evento/' + 'individual');
  }


  getDetallesEvento(idEvento: number){
    this.router.navigate(['/event-details', idEvento])
  }
}




