import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor() { }

    isLoggedIn(): boolean {
        // Lógica para verificar si el usuario está autenticado
        return !!localStorage.getItem('token'); // Ejemplo básico usando localStorage
    }

    login(username: string, password: string){
        localStorage.setItem('token', 'jwt_token'); // Ejemplo básico de almacenamiento de token
    }

    logout(): void {
        localStorage.removeItem('user');
        localStorage.removeItem('token');
    }
}
