import { Component } from '@angular/core';
import { UsuarioEvento } from '../models/interfaces/Usuario.interface';


@Component({
  selector: 'app-certification',
  templateUrl: './certification.component.html',
  styleUrls: ['./certification.component.css']
})
export class CertificationComponent {
  
  Organizado: boolean = false;
  Participantes: UsuarioEvento[] = [];
}