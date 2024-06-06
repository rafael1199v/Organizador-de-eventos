import { Component } from '@angular/core';

@Component({
  selector: 'app-team-event-list',
  templateUrl: './team-event-list.component.html',
  styleUrls: ['./team-event-list.component.css']
})
export class TeamEventListComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
