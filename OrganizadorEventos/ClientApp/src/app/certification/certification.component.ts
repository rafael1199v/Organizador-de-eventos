import { Component } from '@angular/core';
import { UsuarioEvento } from '../models/interfaces/Usuario.interface';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-certification',
  templateUrl: './certification.component.html',
  styleUrls: ['./certification.component.css']
})
export class CertificationComponent {
  nombreEvento: string;

  constructor(private activatedRoute: ActivatedRoute){
    this.nombreEvento = (this.activatedRoute.snapshot.paramMap.get('eventName') || 'Evento');
  }
}
