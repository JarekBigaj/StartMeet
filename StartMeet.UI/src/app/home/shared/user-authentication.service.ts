import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from "@angular/forms";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserAuthenticationService {

  constructor(private fb:FormBuilder, private http:HttpClient) { }

  readonly BaseURI = 'https://localhost:44307/api';

  formModel = this.fb.group({
    FirstName : ['',Validators.required],
    SecondName : ['', Validators.required],
    Email : ['', Validators.email],
    Password : ['',[Validators.required, Validators.minLength(6)]]
  });

  register(){
    var body ={
      FirstName : this.formModel.value.FirstName,
      SecondName: this.formModel.value.SecondName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Password
    };
    return this.http.post(this.BaseURI+'/Home/Register',body);
  }

  login(formData){
    return this.http.post(this.BaseURI+'/Home/Login',formData);
  }
}