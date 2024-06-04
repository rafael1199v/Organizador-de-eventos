import { Component } from '@angular/core';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html'
})
export class EventDetailsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
