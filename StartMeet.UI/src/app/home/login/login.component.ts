import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserAuthenticationService } from '../shared/user-authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  formModel={
    Email: '',
    Password:''
  }

  constructor(private service:UserAuthenticationService, private router: Router, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res:any) => {
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/UserPage');
      },
      err => {
        if(err.status == 400)
          this.toastr.error('Incorrect Email or Password.','Authentication failed');
        else
          console.log(err);
      }
    );

  }
}
