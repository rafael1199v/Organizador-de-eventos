import { Component, ComponentFactoryResolver, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/interfaces/Evento.interface';
import { ActivatedRoute } from '@angular/router';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EquipoService } from '../services/EquipoService';

@Component({
  selector: 'create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.css']
})
export class CreateTeamComponent {
  
  Quantity: number = 1;
  evento?: Evento;
  teamForm!: FormGroup;

  constructor(private activatedRoute: ActivatedRoute, private http:HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder, private equipoService: EquipoService)
  {
    this.Quantity = parseInt(activatedRoute.snapshot.paramMap.get('limit') || '0');
    this.getDetalleEvento().subscribe(resultado => {
      this.evento = resultado;
    }, error => console.log(error));
  }


  ngOnInit(){
    this.teamForm = this.formBuilder.group({
      nombreEquipo: ['', Validators.required],
      nombreOrganizacion: ['', Validators.required],
      datos: this.formBuilder.array([this.initDatos()])
    })


  }

  agregarDato(): void {
    const datos = <FormArray>this.teamForm.controls['datos'];
    datos.push(this.initDatos());
  }


  get datos(){
    return this.teamForm.get('datos') as FormArray;
  }

  removerDato(index: number){
    const datos = <FormArray>this.teamForm.controls['datos'];
    datos.removeAt(index);
  }

  initDatos(){
    return this.formBuilder.group({
      correo: ['', [Validators.required, Validators.email]],
      nombre: ['', Validators.required]
    });
  }

  getDetalleEvento(){
    return this.http.get<Evento>(this.baseUrl + 'evento/detalle/' + this.activatedRoute.snapshot.paramMap.get('id'))
  }

  revisarCampos(): boolean{

    const primerCorreo: string = this.datos.value[0].correo;
    if(this.datos.value.length == 1){
      return true;
    }

    for(let i = 1; i < this.datos.value.length; i++){
      if(primerCorreo == String(this.datos.value[i].correo)){
        return false;
      }
    }

    return true;
  }


  registrarEquipo(){
    if(!this.teamForm.valid){
      alert('Campos invalidos');
    }
    else if(!this.revisarCampos()){
      alert('Mismo participante varias veces registrado');
    }
    else{

      let eventoId: number = parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '-1');
      let representanteId: number = parseInt((JSON.parse(localStorage.getItem('user') || '-1')).usuarioId)
      this.equipoService.registrarEquipo(this.teamForm, eventoId, representanteId).subscribe();
    } 
  }
}




