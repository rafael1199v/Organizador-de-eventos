import { Component, Inject } from '@angular/core';
import { Evento } from '../models/interfaces/Evento.interface';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {
  

  evento!: Evento;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute) {
    this.getDetalleEvento().subscribe(resultado => {
      this.evento = resultado;
      console.log(this.evento);
    }, error => console.log(error));
  }




  getDetalleEvento(){
    return this.http.get<Evento>(this.baseUrl + 'evento/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }
}
