import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { UserProperties } from "./user-properties.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  formData:UserProperties

  constructor(private http:HttpClient) { }

  readonly BaseURI = 'https://localhost:44307/api';

  getUserProfile(){
    return this.http.get(this.BaseURI+'/UserProfile');
  }

  postUserSettings(formData:UserProperties){
    return this.http.post(this.BaseURI+'/UserProfile/Edit',formData)
  }

}
