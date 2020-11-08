import { Component, OnInit } from '@angular/core';
import { UserAuthenticationService } from '../shared/user-authentication.service';
import { ToastrService } from 'ngx-toastr';
import { SelectDate } from '../shared/select-date';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

  constructor(public service:UserAuthenticationService, private toastr: ToastrService) { }

  SelectDateModel:SelectDate;

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        if(res.succeeded){
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.')
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserEmail':
                this.toastr.error('UserEmail is already taken.', 'Registration failed.')
                break;
            
              default:
                this.toastr.error(element.description, 'Registration failed.')
                break;
            }
          });
        }
      },
      err =>{
        console.log(err);
      }
    )
  }
}
