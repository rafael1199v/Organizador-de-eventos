import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/interfaces/Evento.interface';
import { EventoService } from '../services/EventoService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent {

  eventosParticipante: Evento[] = [];
  eventosOrganizador: Evento[] = [];
  participante: boolean = false;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private eventoService: EventoService, private router: Router){
    this.getEventosOrganizador().subscribe(resultado => {
      this.eventosOrganizador = this.eventoService.actualizarFormatoTiempo(resultado);
      console.log(this.eventosOrganizador);
    }, error => console.log(error))

    
    this.getEventosParticipante().subscribe(resultado => {
      this.eventosParticipante = this.eventoService.actualizarFormatoTiempo(resultado);
      console.log(this.eventosParticipante);
    }, error => console.log(error))
  }



  getEventosParticipante() {
    return this.http.get<Evento[]>(this.baseUrl + 'evento/participante/' + (JSON.parse(localStorage.getItem('user') || '-1')).usuarioId);
  }


  getEventosOrganizador() {
    return this.http.get<Evento[]>(this.baseUrl + 'evento/organizador/' + (JSON.parse(localStorage.getItem('user') || '-1')).usuarioId);
  }

  getCertList(idEvento: number, porEquipos: boolean){
    if(porEquipos){
      this.router.navigate(['/final-team-participation', idEvento])
    }
    else{
      this.router.navigate(['/final-participation-individual', idEvento])
    }
    
  }

  getCertification(nombreEvento?: string){
    this.router.navigate(['/certification', nombreEvento])
  }

}
