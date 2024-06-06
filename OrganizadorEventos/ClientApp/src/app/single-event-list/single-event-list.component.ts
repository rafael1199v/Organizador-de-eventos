import { Component } from '@angular/core';

@Component({
  selector: 'app-single-event-list',
  templateUrl: './single-event-list.component.html',
  styleUrls: ['./single-event-list.component.css']
})
export class SingleEventListComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
