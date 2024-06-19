
export interface Evento{
  eventoId: number
  titulo: string,
  descripcion: string,
  inicio: Date,
  finalizacion: Date,
  lugarEvento: string,
  porEquipos: boolean,
  maxPersonasPorEquipo: number,
  organizadorId: number,
  historials: any,
  organizador: any
}


