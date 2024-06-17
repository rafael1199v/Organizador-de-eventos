import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventTeamParticipationComponent } from './event-team-participation.component';

describe('EventTeamParticipationComponent', () => {
  let component: EventTeamParticipationComponent;
  let fixture: ComponentFixture<EventTeamParticipationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventTeamParticipationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventTeamParticipationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
