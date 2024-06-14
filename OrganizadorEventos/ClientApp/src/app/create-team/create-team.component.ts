import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/interfaces/Evento.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.css']
})
export class CreateTeamComponent {
  
  Quantity: number = 1;
  evento?: Evento;
  

  constructor(private activatedRoute: ActivatedRoute, private http:HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {
    this.Quantity = parseInt(activatedRoute.snapshot.paramMap.get('limit') || '0');
    this.getDetalleEvento().subscribe(resultado => {
      this.evento = resultado;
    }, error => console.log(error));
  }
  
  getDetalleEvento(){
    return this.http.get<Evento>(this.baseUrl + 'evento/detalle/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }
}




