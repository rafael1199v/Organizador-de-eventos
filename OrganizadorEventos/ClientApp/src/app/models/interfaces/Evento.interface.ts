import { Data } from "popper.js"

export interface Evento{
    eventoId: number
    titulo: string,
    descripcion: string,
    inicio: Date,
    finalizacion: Date,
    lugarEvento: string,
    organizadorId: number,
    historials: any,
    organizador: any
}


export interface Usuario{

  usuarioId: number,
  nombre: string,
  direccion: string,
  fechaNacimiento: Date,
  correo: string,
  telefono: string,
  organizacion: string,
  cargo: string,
  equipos: any,
  eventos: any,
  historials: any,
  miembrosEquipos: any,
  participanteEventos: any
}