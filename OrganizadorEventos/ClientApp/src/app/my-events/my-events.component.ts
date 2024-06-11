import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Evento, Usuario } from '../models/interfaces/Evento.interface';
import { Router } from '@angular/router';





@Component({
  selector: 'app-my-events',
  templateUrl: './my-events.component.html',
  styleUrls: ['./my-events.component.css']
})
export class MyEventsComponent {

  misEventos: Evento[] = [];
  eventosEnCurso: Evento[] = [];
  eventosFuturos: Evento[] = [];
  fecha: Date = new Date();
  constructor(private http : HttpClient, private route: ActivatedRoute, @Inject('BASE_URL') private baseUrl: string, private router: Router){
    this.getEventos().subscribe(resultado =>{
      this.misEventos = resultado;
      this.clasificarEventos(this.misEventos, this.eventosEnCurso, this.eventosFuturos);
      console.log(this.misEventos);
    }, error => console.log(error))
  }


  //Consigue los eventos que todavia siguen vigentes para su realizacion (Falta modificar el backend para el correcto funcionamiento)

  getEventos(){
    let usuario: Usuario = JSON.parse(localStorage.getItem('user') || '{}')
    return this.http.get<Evento[]>(this.baseUrl + 'evento/' + usuario.usuarioId)
  }

  clasificarEventos(eventos: Evento[], eventosEnCurso: Evento[], eventosFuturos: Evento[]){
    for(let i = 0; i < eventos.length; i++){
      eventos[i].inicio = new Date(eventos[i].inicio);
      eventos[i].finalizacion = new Date(eventos[i].finalizacion);

      if(eventos[i].inicio.getTime() > this.fecha.getTime()){
        eventosFuturos.push(eventos[i]);
      }
      else{
        eventosEnCurso.push(eventos[i]);
      }
    }
  }


  participacionEvento(idEvento: number, porEquipos: Boolean){
    this.router.navigate(['/event-participation', idEvento, porEquipos])
  }
  

}
