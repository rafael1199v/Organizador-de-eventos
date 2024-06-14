import { Component } from '@angular/core';
import { Usuario } from '../models/interfaces/Usuario.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.css']
})
export class CreateTeamComponent {
  
  Quantity: number = 1;

  constructor(private activatedRoute: ActivatedRoute)
  {
    this.Quantity = parseInt(activatedRoute.snapshot.paramMap.get('limit') || '0');
  }
  

}




