import { Component } from '@angular/core';
import { Usuario } from '../models/interfaces/Usuario.interface';
import { AuthService } from '../services/AuthService';

@Component({
  selector: 'app-home',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  usuario?: Usuario;

  constructor(private authService: AuthService){
    this.usuario = JSON.parse(localStorage.getItem("user") || '');
  }

  logout(){
    this.authService.logout();
  }
}
