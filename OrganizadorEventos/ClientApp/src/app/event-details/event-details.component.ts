import { Component, Inject } from '@angular/core';
import { Evento } from '../models/interfaces/Evento.interface';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { EventoService } from '../services/EventoService';



@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {
  

  evento?: Evento;
  inscrito: boolean = true;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, private route: Router, private eventoService: EventoService) {
    this.getDetalleEvento().subscribe(resultado => {
      this.evento = resultado;
    }, error => console.log(error));

    this.eventoService.verificarRegistro(parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '-1'),parseInt((JSON.parse(localStorage.getItem('user') || '-1')).usuarioId)).subscribe(resultado => {
      this.inscrito = resultado;
      console.log(this.inscrito)
    }, error => console.log(error))
  }




  getDetalleEvento(){
    return this.http.get<Evento>(this.baseUrl + 'evento/detalle/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }


  inscripcionIndividual(){
    const eventoId : number = (this.evento?.eventoId ||  -1);
    return this.eventoService.inscripcionIndividual(eventoId, parseInt((JSON.parse(localStorage.getItem('user') || '-1')).usuarioId))
  }


  inscripcion(){
    if(this.evento?.porEquipos){
      this.route.navigate(['/create-team',this.evento.eventoId ,this.evento.maxPersonasPorEquipo])
    }
    else{
      this.inscripcionIndividual().subscribe(resultado => {this.inscrito = true}, error => console.log(error));
    }
  }

  textoInscripcion(){
    if(this.evento?.porEquipos){
      return "Crear un equipo!"
    }
    else{
      return "Participar!"
    }
  }
}
