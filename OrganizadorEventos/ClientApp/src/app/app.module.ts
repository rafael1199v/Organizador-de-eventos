import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SingleEventListComponent } from './single-event-list/single-event-list.component';
import { TeamEventListComponent } from './team-event-list/team-event-list.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { AppRoutingModule } from './app-routing.module';
import { UserComponent } from './user/user.component';
import { CreateTeamComponent } from './create-team/create-team.component';
import { MyEventsComponent } from './my-events/my-events.component';
import { EventParticipationComponent } from './event-participation/event-participation.component';
import { HistoryComponent } from './history/history.component';
import { EventoService } from './services/EventoService';
import { UsuarioService } from './services/UsuarioService';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    SingleEventListComponent,
    TeamEventListComponent,
    CreateEventComponent,
    EventDetailsComponent,
    UserComponent,
    CreateTeamComponent,
    MyEventsComponent,
    EventParticipationComponent,
    HistoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent},
      { path: 'register', component: RegisterComponent},
      { path: 'single-event-list', component: SingleEventListComponent},
      { path: 'team-event-list', component: TeamEventListComponent},
      { path: 'create-event', component: CreateEventComponent},
      { path: 'event-details/:id', component: EventDetailsComponent},
      { path: 'user', component: UserComponent},
      { path: 'create-team/:id/:limit', component: CreateTeamComponent},
      { path: 'my-events', component: MyEventsComponent},
      { path: 'event-participation/:id/:teamOrsingle', component: EventParticipationComponent},
      { path: 'history', component: HistoryComponent}
    ]),
    AppRoutingModule
  ],
  providers: [EventoService, UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
