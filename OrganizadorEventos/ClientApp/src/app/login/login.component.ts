import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router, 
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]], 
      password: ['', Validators.required]
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
          this.router.navigate(['/home']);
    } else {
      console.log('error');
    }
  }

  login(loginObj: any) {
    const user = {
      correo: this.loginForm.value.email, 
      contrasenha: this.loginForm.value.password
    };
    return this.http.post<any>(this.baseUrl + 'usuario', user);
  }
}
