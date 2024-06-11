import { Component } from '@angular/core';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent {
  Quantity:number = 1;
  isTeamEvent:boolean = false;

  TeamClick(){
    if(this.isTeamEvent){
      this.isTeamEvent = false
      this.Quantity = 1;
    }
    else{
      this.isTeamEvent = true
    }
  }

}
