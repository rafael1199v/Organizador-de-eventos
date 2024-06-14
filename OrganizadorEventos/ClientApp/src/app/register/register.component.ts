import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { UsuarioService } from '../services/UsuarioService';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm!: FormGroup;

  constructor(private http: HttpClient, private formBuilder: FormBuilder, @Inject('BASE_URL') private baseUrl: string, private usuarioService: UsuarioService){
    
  }

  ngOnInit(): void{
    this.registerForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      direccion: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
      prefijo: [Validators.required],
      telefono: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(8)]],
      organizacion: ['', Validators.required],
      cargo: ['', Validators.required],
      contrasenha: ['', [Validators.required, Validators.minLength(5)]],
      contrasenhaRep: ['', [Validators.required, Validators.minLength(5)]]
    })
  }


  


  registrarUsuario(){
    if(!this.registerForm.valid){
      alert("Campos invalidos")
    }
    else if(this.registerForm.value.contrasenha != this.registerForm.value.contrasenhaRep){
      alert("Contrasenhas diferentes")
    }
    else{
      this.usuarioService.registrarUsuario(this.registerForm).subscribe( resultado =>{
        alert("Usuario Registrado")
        this.registerForm.reset();
      }, error => console.log(error));
    }
  }


}
