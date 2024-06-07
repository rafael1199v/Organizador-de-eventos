import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Evento, Usuario } from '../models/interfaces/Evento.interface';


@Component({
  selector: 'app-my-events',
  templateUrl: './my-events.component.html',
  styleUrls: ['./my-events.component.css']
})
export class MyEventsComponent {

  misEventos: Evento[] = [];

  constructor(private http : HttpClient, private route: ActivatedRoute, @Inject('BASE_URL') private baseUrl: string){
    this.getEventos().subscribe(resultado =>{
      this.misEventos = resultado;
      console.log(this.misEventos);
    }, error => console.log(error))
  }


  getEventos(){
    let usuario: Usuario = JSON.parse(localStorage.getItem('user') || '{}')
    return this.http.get<Evento[]>(this.baseUrl + 'evento/' + usuario.usuarioId)
  }
}
