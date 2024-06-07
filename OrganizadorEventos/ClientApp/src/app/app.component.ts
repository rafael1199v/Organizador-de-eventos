import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, Event} from '@angular/router';
import { filter } from 'rxjs/operators';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'app';
  showNavbar = true;
  

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events
      .pipe(
        filter((event: Event): event is NavigationEnd => event instanceof NavigationEnd)
      )
      .subscribe((event: NavigationEnd) => {
        const url = event.urlAfterRedirects;
        this.showNavbar = this.shouldShowNavbar(url);
      });
  }

  shouldShowNavbar(url: string): boolean {
    // Define las rutas donde NO quieres mostrar el navbar
    const noNavbarRoutes = ['/register','/login'];
    return !noNavbarRoutes.includes(url);
  }
}
