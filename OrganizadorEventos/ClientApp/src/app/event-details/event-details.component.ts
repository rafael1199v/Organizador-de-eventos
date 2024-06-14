import { Component, Inject } from '@angular/core';
import { Evento } from '../models/interfaces/Evento.interface';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../models/interfaces/Usuario.interface';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {
  

  evento?: Evento;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, private route: Router) {
    this.getDetalleEvento().subscribe(resultado => {
      this.evento = resultado;
    }, error => console.log(error));
  }




  getDetalleEvento(){
    return this.http.get<Evento>(this.baseUrl + 'evento/detalle/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }


  inscripcionIndividual(){
    return this.http.post<Usuario>(this.baseUrl + 'endpoint', (JSON.parse(localStorage.getItem('user') || '-1').usuarioId));
  }


  inscripcion(){
    if(this.evento?.porEquipos){
      this.route.navigate(['/create-team',this.evento.eventoId ,this.evento.maxPersonasPorEquipo])
    }
    else{
      this.inscripcionIndividual().subscribe();
    }
  }
}
