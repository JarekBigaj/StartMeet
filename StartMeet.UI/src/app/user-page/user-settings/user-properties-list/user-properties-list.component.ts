import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-user-properties-list',
  templateUrl: './user-properties-list.component.html',
  styles: [
  ]
})
export class UserPropertiesListComponent implements OnInit {

  constructor(public service:UserService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }
  
  resetForm(form?:NgForm){
    if(form!=null)
      form.resetForm();
    this.service.formData ={
      Email:'',
      Password:''
    }
  }

  onSubmit(form:NgForm){
    this.service.postUserSettings(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Edit successfully','Edit Account');
      },
      err => {
        console.log(err);
      }
    )
  }
}
