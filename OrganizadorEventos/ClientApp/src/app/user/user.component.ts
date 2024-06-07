import { Component } from '@angular/core';
import { Usuario } from '../models/interfaces/Evento.interface';

@Component({
  selector: 'app-home',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  usuario!: Usuario;

  constructor(){
    this.usuario = JSON.parse(localStorage.getItem("user") || '');
  }

  
}
