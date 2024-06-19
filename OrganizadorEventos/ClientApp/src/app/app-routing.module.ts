// import { NgModule } from '@angular/core';
// import { RouterModule, Routes } from '@angular/router';
// import { LoginComponent } from './login/login.component';
// import { HomeComponent } from './home/home.component';
// import { RegisterComponent } from './register/register.component';
// import { PageNotFoundComponent } from './PageNotFound/page-not-found.component';
// import { AuthGuard } from './guards/auth.guard';
// import { HistoryComponent } from './history/history.component';
// import { SingleEventListComponent } from './single-event-list/single-event-list.component';
// import { TeamEventListComponent } from './team-event-list/team-event-list.component';
// import { CreateEventComponent } from './create-event/create-event.component';
// import { MyEventsComponent } from './my-events/my-events.component';
// import { UserComponent } from './user/user.component';

// const routes: Routes = [
//   { path: '', redirectTo: '/login', pathMatch: 'full' },
//   { path: 'login', component: LoginComponent },
//   { path: 'register', component: RegisterComponent },
//   { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
//   { path: 'history', component: HistoryComponent, canActivate: [AuthGuard] },
//   { path: 'single-event-list', component: SingleEventListComponent, canActivate: [AuthGuard] },
//   { path: 'team-event-list', component: TeamEventListComponent, canActivate: [AuthGuard] },
//   { path: 'create-event', component: CreateEventComponent, canActivate: [AuthGuard] },
//   { path: 'my-events', component: MyEventsComponent, canActivate: [AuthGuard] },
//   { path: 'user', component: UserComponent, canActivate: [AuthGuard] },
//   { path: '**', component: PageNotFoundComponent },
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
