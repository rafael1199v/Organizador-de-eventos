import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { EquipoService } from "src/app/services/EquipoService";
import { Equipo } from "src/app/models/interfaces/Equipo.interface";

@Component({
    selector: 'app-final-team-list',
    templateUrl: './final-team-participation.component.html',
    styles : ['']
})
export class FinalTeamParticipationListComponent{

    equipos: Equipo[] = [];
    
    constructor(private http: HttpClient, private activatedRoute: ActivatedRoute, private equipoService: EquipoService){
        this.getEquiposListaFinal();
    }

    getEquiposListaFinal(){
        const eventoId: string = (this.activatedRoute.snapshot.paramMap.get('eventId') || '-1');
        this.equipoService.getListaFinalEquiposParticipacion(eventoId).subscribe(resultado => {
            this.equipos = resultado;
        }, error => console.log(error));
    }
}