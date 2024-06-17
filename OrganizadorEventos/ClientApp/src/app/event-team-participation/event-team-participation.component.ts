import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Equipo } from '../models/interfaces/Equipo.interface';
import { EventoService } from '../services/EventoService';

@Component({
  selector: 'app-event-team-participation',
  templateUrl: './event-team-participation.component.html',
  styleUrls: ['./event-team-participation.component.css']
})
export class EventTeamParticipationComponent {
  equipos: Equipo[] = []
   
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, private eventoService: EventoService, private router: Router){
    this.getParticipants().subscribe( resultado => {
      this.equipos = resultado;
      console.log(this.equipos);
    }, error => console.log(error));
  }




  getParticipants(){
    return this.http.get<Equipo[]>(this.baseUrl + 'equipo/participacion/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }


  guardarAsistenciaEquipos(){
    this.eventoService.guardarAsistenciaEquipo((this.activatedRoute.snapshot.paramMap.get('id') || '-1'), this.equipos).subscribe(resultado => {alert('Cambios guardados')},);
    this.router.navigate(['/my-events'])
  }

  verificarAsistencia(equipo: Equipo){
    equipo.asistencia = !equipo.asistencia;
  }
}
