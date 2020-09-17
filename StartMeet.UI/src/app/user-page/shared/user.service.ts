import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  readonly BaseURI = 'https://localhost:44307/api';

  getUserProfile(){
    return this.http.get(this.BaseURI+'/UserProfile');
  }
}
