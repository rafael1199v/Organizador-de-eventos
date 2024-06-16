import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { EventoService } from '../services/EventoService';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent {
  cantidadPersonas:number = 1;
  esEventoGrupo:boolean = false;
  eventoForm!: FormGroup;


  constructor(private http: HttpClient, private formBuilder: FormBuilder, private eventoService: EventoService){}

  
  ngOnInit(): void{
    this.eventoForm = this.formBuilder.group({
      titulo: ['', Validators.required],
      lugarEvento: ['', Validators.required],
      inicio: ['', Validators.required],
      finalizacion: ['', Validators.required],
      descripcion: ['', [Validators.required, Validators.maxLength(300)]]
    })
  }
 
  TeamClick(){
    if(this.esEventoGrupo){
      this.esEventoGrupo = false
      this.cantidadPersonas = 1;
    }
    else{
      this.esEventoGrupo = true
    }
  }

  crearEvento(){
    if(!this.eventoForm.valid){
      alert('Campos incorrectos')
    }
    else if(new Date(this.eventoForm.value.inicio).getTime() >= new Date(this.eventoForm.value.finalizacion).getTime()){
      alert('Fechas incorrectas');
    }
    else if(new Date(this.eventoForm.value.finalizacion).getTime() <= Date.now()){
      alert('La fecha ya pasó')
    }
    else{
      this.eventoService.crearEvento(this.eventoForm, this.esEventoGrupo, this.cantidadPersonas, JSON.parse(localStorage.getItem('user') || '{}')).subscribe( result =>
        {}, error => console.log(error)
      );
    }
  }

}
