import { Component} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onLogin(){
    if(this.loginForm.valid){
      this.login(this.loginForm.value).subscribe(result=>{
          console.log(result);
        },
        error => console.log(error)
      );
    }
    else{
      console.log("error")
    }
  }


  login(loginObj: any){
    const user = {
      correo: this.loginForm.value.username,
      contrasenha: this.loginForm.value.password
    }
    return this.http.post<any>(this.baseUrl + "usuario", user);
  }

}

