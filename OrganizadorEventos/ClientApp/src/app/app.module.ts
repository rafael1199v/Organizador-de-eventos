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
// import { AppRoutingModule } from './app-routing.module';
import { UserComponent } from './user/user.component';
import { CreateTeamComponent } from './create-team/create-team.component';
import { MyEventsComponent } from './my-events/my-events.component';
import { EventParticipationComponent } from './event-participation/event-participation.component';
import { HistoryComponent } from './history/history.component';
import { EventoService } from './services/EventoService';
import { UsuarioService } from './services/UsuarioService';
import { EquipoService } from './services/EquipoService';
import { EventTeamParticipationComponent } from './event-team-participation/event-team-participation.component';
import { CertificationComponent } from './certification/certification.component';
import { PageNotFoundComponent } from './PageNotFound/page-not-found.component';
import { AuthService } from './services/AuthService';
import { AuthGuard } from './guards/auth.guard';



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
    HistoryComponent,
    EventTeamParticipationComponent,
    CertificationComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '',  redirectTo: '/login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'single-event-list', component: SingleEventListComponent, canActivate: [AuthGuard] },
      { path: 'team-event-list', component: TeamEventListComponent, canActivate: [AuthGuard] },
      { path: 'create-event', component: CreateEventComponent, canActivate: [AuthGuard] },
      { path: 'event-details/:id', component: EventDetailsComponent, canActivate: [AuthGuard] },
      { path: 'user', component: UserComponent, canActivate: [AuthGuard] },
      { path: 'create-team/:id/:limit', component: CreateTeamComponent, canActivate: [AuthGuard] },
      { path: 'my-events', component: MyEventsComponent, canActivate: [AuthGuard] },
      { path: 'event-participation/:id/:teamOrsingle', component: EventParticipationComponent, canActivate: [AuthGuard] },
      { path: 'history', component: HistoryComponent, canActivate: [AuthGuard] },
      { path: 'event-team-participation/:id/:teamOrsingle', component: EventTeamParticipationComponent, canActivate: [AuthGuard] },
      { path: 'certification', component: CertificationComponent, canActivate: [AuthGuard] },
      { path: '**', component: PageNotFoundComponent },
    ]),
    // AppRoutingModule
  ],
  providers: [EventoService, UsuarioService, EquipoService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
