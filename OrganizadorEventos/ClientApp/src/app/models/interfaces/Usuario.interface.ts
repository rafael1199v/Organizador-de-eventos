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
  
export interface UsuarioEvento{
    usuarioId: number,
    nombre: string,
    correo: string,
    organizacion: string,
    asistencia: boolean
}