import { Component } from '@angular/core';
import { AuthService } from '../services/AuthService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
  constructor(private authSerice: AuthService){}


  logout(){
    this.authSerice.logout();
  }
}
