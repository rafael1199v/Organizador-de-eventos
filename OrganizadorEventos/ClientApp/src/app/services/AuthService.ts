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

    login(username: string, password: string): boolean {
        // Lógica para autenticar al usuario y guardar el token en localStorage
        // Aquí deberías implementar la lógica de autenticación con tu backend
        if (username === 'usuario' && password === 'password') {
            localStorage.setItem('token', 'jwt_token'); // Ejemplo básico de almacenamiento de token
            return true;
        }
        return false;
    }

    logout(): void {
        // Lógica para cerrar sesión (limpiar token, etc.)
        localStorage.removeItem('token');
    }
}
